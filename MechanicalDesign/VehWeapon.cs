using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MechanicalDesign
{
    [Serializable]
    public class VehWeapon 
    {
        public MongoDB.Bson.ObjectId _id;
        public String Name;
        public String ACC;
        public String DMG;
        public String ROF;
        public String AMMO;
        public String AMMO_TYPE;
        public String Range;
        public String Special;
        public String HPTYPE;
        public String CPX;
        public Int32 AMMO_COST;
        public Int32 COST;

        public VehWeapon(String n, String ac, String dm, String ro, String am, String amt, String ra, String s, String hp,String cpx,Int32 amcost, Int32 cost)
        {
             Name = n;
             ACC= ac;
             DMG = dm;
             ROF= ro;
             AMMO= am;
             AMMO_TYPE = amt;
             Range= ra;
             Special = s;
             HPTYPE = hp;
             CPX = cpx;
            AMMO_COST = amcost;
            COST = cost;
        }
        public VehWeapon()
        {

        }
    }
}
