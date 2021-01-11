using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace wedding_planner.Models
{
    public class DashboardWrapper
    {
        public User ThisUser {get;set;}
        public List<Wedding> AllWeddings {get;set;}
        
    }
}//end namespace