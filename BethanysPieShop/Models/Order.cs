﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BethanysPieShop.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your address")]
        [Display(Name = "Address line 1")]
        [StringLength(100)]
        public string AddressLine1 { get; set; }
        [Display(Name = "Address line 2")]
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage = "Please enter your zip code")]
        [Display(Name = "Zip Code")]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(10)]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(50)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }
    }
}