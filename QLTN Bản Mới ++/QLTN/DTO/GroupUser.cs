using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DTO
{
    public class GroupUser
    {
        public GroupUser(int id, string name)
        {
            this.groupUser = id;
            this.GroupName = name;
        }
        //GroupUser	GroupName
        public GroupUser(DataRow row)
        {
            this.groupUser = (int)row["GroupUser"];
            this.GroupName = row["GroupName"].ToString();
        }

        private string name;

        public string GroupName
        {
            get { return name; }
            set { name = value; }
        }

        private int iD;

        public int groupUser
        {
            get { return iD; }
            set { iD = value; }
        }
    } 
}
