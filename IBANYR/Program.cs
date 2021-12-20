using System;
using System.Threading;
using System.Windows.Forms;

namespace IBANYR
{
    static class Program
    {
        static bool createdNew;
        static Mutex mutex = new Mutex(true, Application.ProductName, out createdNew);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try
                {
                    AppSetting appSetting = new AppSetting();
                    if (String.IsNullOrEmpty(appSetting.GetConnectionString()))
                    {
                        FrmSetConnectionString frm = new FrmSetConnectionString();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            appSetting.SaveConnectionString(frm.ConnectionString);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Végzetes hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    while (!DBManager.TestConnection() && MessageBox.Show("Az adatbáziskapcsolat beállításai nem megfelelőek vagy az adatbázis szerver nem elérhető!\n\rKívánja módosítani a kapcsolat beállításait?", "Csatlakozási hiba", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        AppSetting appSetting = new AppSetting();
                        FrmSetConnectionString frm = new FrmSetConnectionString();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            appSetting.SaveConnectionString(frm.ConnectionString);
                        }
                    }
                    DBManager.OpenConnection();
                    using (FrmLogin frm = new FrmLogin())
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            if (DBManager.IsTimeToUpdatePw(frm.User))
                            {
                                FrmChangePassword frmPwChange = new FrmChangePassword(frm.User);
                                if (frmPwChange.ShowDialog() == DialogResult.OK)
                                {
                                    MessageBox.Show($"Jelszó módosítása sikeres!", "Jelszómódosítás...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    SystemLog.WriteLogEvent(frm.User, EventType.ownPasswordChange);
                                    SystemLog.WriteLogEvent(frm.User, EventType.login);
                                    Application.Run(new FrmMain(frm.User));
                                }
                            }
                            else
                            {
                                SystemLog.WriteLogEvent(frm.User, EventType.login);
                                Application.Run(new FrmMain(frm.User));
                            }
                        }
                        else
                        {
                            DBManager.CloseConnection();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Végzetes hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("A program egy példánya már fut! Kérem, ellenőrizze!", "Figyelmeztetés...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
