using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.ServiceProcess;

namespace WLB_Management_Service.Test
{
     [TestFixture]

        public class GitTesting1Test
        {
            [TestCase]
            public void WriteFileTest()
            {
                WLB_Management_Service.Service1 helper = new WLB_Management_Service.Service1();
                bool result = helper.WriteFile();
                Assert.IsTrue(result);
            }
            //[TestCase]

            //public void SubtractTest()
            //{
            //    WLBManagement.Service1 helper = new WLBManagement.Service1();
            //    SessionChangeDescription strReason1;
            //    bool result = helper.InsertSesssionDetails(strReason1);
            //    Assert.IsTrue(result);
            //}

        }
    
}
