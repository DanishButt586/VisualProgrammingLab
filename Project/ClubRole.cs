using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _233606_LabMid_main_file_
{
    internal class ClubRole
    {

        private string name;
        private string role;
        private string contactInfo;

        public ClubRole()
        {
            name = "NULL";
            role = "NULL";
            contactInfo = "NULL";
        }
        public void setName(string n)
        {
            name = n;
        }
        public void setRole(string r)
        {
            role = r;
        }
        public void setContactInfo(string cn)
        {
            contactInfo = cn;
        }

        public string getName()
        {
            return name;
        }
        public string getRole()
        {
            return role;
        }
        public string getContactInfo()
        {
            return contactInfo;
        }

    }
}
