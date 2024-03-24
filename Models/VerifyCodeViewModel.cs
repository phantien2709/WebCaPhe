using AspNetCoreHero.ToastNotification.Abstractions;
using doan.Controllers.Authentication;
using doan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doan.Models
{

    public class VerifyCodeViewModel
    {
        public string Code { get; set; }
        public string Phone { get; set; }

        public VerifyCodeViewModel()
        {
            // Initialize any properties or perform any setup here
        }
        public VerifyCodeViewModel(string code, string phone)
        {
            Code = code;
            Phone = phone;
        }

    }
}