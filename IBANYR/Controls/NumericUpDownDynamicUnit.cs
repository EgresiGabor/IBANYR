using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    enum UnitTypes
    {
        Default,
        Weight,
        Distance,
        Time,
        Storage
    }
    internal partial class NumericUpDownDynamicUnit : NumericUpDown
    {
        Dictionary<string, int> unitAndGearNum;
        UnitTypes uniteType;
        bool activeControl;
        public Dictionary<string, int> UnitAndGearNum { get => unitAndGearNum; set => unitAndGearNum = value; }
        public override string Text
        {
            get => base.Text;
            set
            {
                if (!activeControl && unitAndGearNum != null && unitAndGearNum.Count > 0)
                {
                    string toText = "";
                    if (Value != 0)
                    {
                        decimal partValue = Value;
                        for (int i = 0; i < unitAndGearNum.Count; i++)
                        {
                            if (partValue / unitAndGearNum.Values.ElementAt(unitAndGearNum.Count - (i + 1)) >= 1)
                            {
                                toText += $"{(String.IsNullOrEmpty(toText) ? "" : " ")}{Math.Truncate(partValue / unitAndGearNum.Values.ElementAt(unitAndGearNum.Count - (i + 1)))} {unitAndGearNum.Keys.ElementAt(unitAndGearNum.Count - (i + 1))}";
                                partValue = partValue % unitAndGearNum.Values.ElementAt(unitAndGearNum.Count - (i + 1));
                            }
                        }
                    }
                    else
                    {
                        toText = $"0 {unitAndGearNum.Keys.ElementAt(0)}";
                    }
                    base.Text = toText;
                }
                else
                {
                    base.Text = value;
                }
            }
        }
        public UnitTypes UniteType
        {
            get => uniteType;
            set
            {
                if (Enum.IsDefined(typeof(UnitTypes), value))
                {
                    uniteType = value;
                    unitAndGearNum.Clear();
                    switch (uniteType)
                    {
                        case UnitTypes.Weight:
                            unitAndGearNum.Add("g", 1);
                            unitAndGearNum.Add("dkg", 100);
                            unitAndGearNum.Add("kg", 1000);
                            unitAndGearNum.Add("t", 1000000);
                            break;
                        case UnitTypes.Distance:
                            unitAndGearNum.Add("mm", 1);
                            unitAndGearNum.Add("cm", 10);
                            unitAndGearNum.Add("dm", 100);
                            unitAndGearNum.Add("m", 1000);
                            unitAndGearNum.Add("km", 1000000);
                            break;
                        case UnitTypes.Time:
                            unitAndGearNum.Add("óra", 1);
                            unitAndGearNum.Add("nap", 24);
                            unitAndGearNum.Add("hét", 168);
                            break;
                        case UnitTypes.Storage:
                            unitAndGearNum.Add("MB", 1);
                            unitAndGearNum.Add("GB", 1000);
                            unitAndGearNum.Add("TB", 1000000);
                            unitAndGearNum.Add("PB", 1000000000);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    throw new ArgumentException("Csak meghatározott értéket adhat meg az egység értékének!");
                }
            }
        }
        public NumericUpDownDynamicUnit() : base()
        {
            activeControl = false;
            unitAndGearNum = new Dictionary<string, int>();
            Enter += NumericUpDownDynamicUnit_Enter;
            Leave += NumericUpDownDynamicUnit_Leave;
        }
        private void NumericUpDownDynamicUnit_Leave(object sender, EventArgs e)
        {
            activeControl = false;
            Text = Value.ToString();
        }

        private void NumericUpDownDynamicUnit_Enter(object sender, EventArgs e)
        {
            activeControl = true;
            Text = Value.ToString();
        }
    }
}
