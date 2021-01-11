using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace asp_exam.Models
{
    public class DashboardWrapper
    {
        public User ThisUser {get;set;}
        public List<PActivity> AllActivities {get;set;}
        
        public PActivity ThisTruck {get;set;}
        public User ActivityCreator {get;set;}
    }
}//end namespace