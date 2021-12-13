using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickEggGo
{
    public class Employee
    {
        private static object previousMenuItem;
        private static int previousQuantity;
        private int quantity;
        private object menuItem;
        public static int requests = 0;
        private int statusFood = 0;
        public Employee()
        { }
        public object NewRequest(int Quantity, object MenuItem)
        {
            this.quantity = Quantity;
            previousQuantity = Quantity;
            requests++;
            statusFood = 0;
            if (requests % 3 == 0)
            {
                if (MenuItem is EggOrder)
                {
                    MenuItem = new ChickenOrder(Quantity);
                }
                else
                {
                    MenuItem = new EggOrder(Quantity);
                }
            }
            this.menuItem = MenuItem;
            previousMenuItem = menuItem;
            return menuItem;
        }

        public object CopyRequest()
        {
            if (requests == 0)
            {
                throw new Exception("Nothing to copy");
            }
            else
            {
                return NewRequest(previousQuantity, previousMenuItem);
            }
        }

        public string Inspect(object item)
        {
            string result = "";
            if (item is EggOrder)
            {
                result = ((EggOrder)item).GetQuality().ToString();
            }
            //else
            //{
            //    result = "no inspection is required";
            //}
            return result;
        }

        public string PrepareFood(object item)
        {
            string result = "";
            if (this.statusFood != 1)
            {
                if (item is ChickenOrder)
                {
                    for (int i = 0; i <= ((ChickenOrder)item).GetQuantity(); i++)
                    {
                        ((ChickenOrder)item).CutUp();
                    }
                    ((ChickenOrder)item).Cook();
                    result = "Prepared " + this.quantity.ToString() + " Chicken(s)";
                }
                else if (item is EggOrder)
                {
                    for (int i = 0; i <= ((EggOrder)item).GetQuantity(); i++)
                    {
                        try
                        {
                            ((EggOrder)item).Crack();
                            result = "Good";
                        }
                        catch (Exception e)
                        {
                            result = e.Message.ToString();
                        }
                        ((EggOrder)item).DiscardShell();
                    }
                    ((EggOrder)item).Cook();
                    result = "Prepared " + this.quantity.ToString() + " " + result + " egg(s)";
                }
                else
                {
                    throw new Exception("First make request");
                }
                statusFood = 1;
                return result;
            }
            else
            {
                throw new Exception("Cannot preapre twice");
            }

        }

    }
}
