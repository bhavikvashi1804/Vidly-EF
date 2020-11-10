﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter a Customer Name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsMember { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }

        
        
        [Display(Name="Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? DOB { get; set; }
    }

}