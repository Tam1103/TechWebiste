﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TechWebsite.Models;

namespace TechWebsite.Security
{
    public class SecurityManager
    {
        public string CookieAuthen { get; private set; }

        public async void SignIn(HttpContext httpcontext, Account account)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(getUserClaims(account),
                CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
            await httpcontext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }


        public async void SignOut(HttpContext htttpcontext)
        {
            await htttpcontext.SignOutAsync();
        }


        private IEnumerable<Claim> getUserClaims(Account account)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, account.Username));

            account.RoleAccounts.ToList().ForEach(ra =>
            {
                claims.Add(new Claim(ClaimTypes.Role, ra.Role.Name));
            });
            return claims;
        }
    }
}
