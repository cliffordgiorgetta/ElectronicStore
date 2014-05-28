using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ElectronicStore.Models
{
    
    [MetadataType(typeof(paymentMetadata))]
    public partial class payment
    {

    }

   public class paymentMetadata 
    {
        [Required
        , MaxLength(16, ErrorMessage="Must be 16 characters")
        , DataType(DataType.CreditCard)
        , MinLength(16, ErrorMessage="Must be 16 characters long")]
        public string CCNumber;

        [Required
         , MaxLength(50, ErrorMessage = "Must be 50 characters")
         , MinLength(50, ErrorMessage = "Must be 50 characters")]
        public string CCexpiremonth;

        [Required
        , MaxLength(50, ErrorMessage = "Must be 50 characters")
        , MinLength(50, ErrorMessage = "Must be 50 characters")]
        public string CCcvc;

        [Required
        , MaxLength(50, ErrorMessage = "Must be 50 characters")
        , MinLength(50, ErrorMessage = "Must be 50 characters")]
        public string CCexpireyear;

        [Required
        , MaxLength(50, ErrorMessage = "Must be 50 characters")
        , MinLength(50, ErrorMessage = "Must be 50 characters")]
        public string name;

        [Required
       , MaxLength(50, ErrorMessage = "Must be 50 characters")
       , MinLength(50, ErrorMessage = "Must be 50 characters")]
        public string confirmationNumber;
       
    }


    [MetadataType(typeof(shippingMetadata))]
    public partial class shippingAddress
    {

    }
    public class shippingMetadata
    {
        [Required
          , MaxLength(100, ErrorMessage = "Must be 100 characters")
          , MinLength(2, ErrorMessage = "Address is too short")]
        public string shipping;

        [Required
        , MaxLength(100, ErrorMessage ="Must be 100 characters")
        , MinLength(100, ErrorMessage="Must be 100 characters")]
            public string state;

        [Required
       , MaxLength(100, ErrorMessage = "Must be 100 characters")
        , MinLength(100, ErrorMessage = "Must be 100 characters")]
        public string city;

        [Required
         , MaxLength(100, ErrorMessage = "Must be 100 characters")
        , MinLength(100, ErrorMessage = "Must be 100 characters")]
        public string zipcode;

        [Required
         , MaxLength(100, ErrorMessage = "Must be 100 characters")
        , MinLength(100, ErrorMessage = "Must be 100 characters")]
        public string type;

        [Required
         , MaxLength(100, ErrorMessage = "Must be 100 characters")
        , MinLength(100, ErrorMessage = "Must be 100 characters")]
        public string name;





    }


   
}