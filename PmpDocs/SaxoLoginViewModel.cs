using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace OpenApi.Web.Models.Logins
{
    public class SaxoLoginViewModel
    {
        public SaxoLoginViewModel(string authenticationUrl, string applicationUrl)
        {
            this.ApplicationUrl = applicationUrl;
            this.AuthenticationUrl = authenticationUrl;
        }

        [Display(Name = "Application Url")]
        public string ApplicationUrl { get; set; }

        [Display(Name = "Authentication Url")]
        public string AuthenticationUrl { get; set; }

        [Display(Name = "SAML Request")]
        public string SamlRequest
        {
            get
            {
                return this.BuildSamlRequest(AuthenticationUrl, ApplicationUrl, ApplicationUrl);
            }
        }

        [Display(Name = "Serialzed SAML Request")]
        public string SerialzedSamlRequest
        {
            get
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(SamlRequest));
            }
        }

        private string BuildSamlRequest(string authenticationUrl, string applicationUrl, string issuerUrl)
        {
            var timestamp = $"{DateTime.UtcNow.ToString("s")}Z";

            return $@"
                    <samlp:AuthnRequest ID=""_{Guid.NewGuid()}"" Version=""2.0"" ForceAuthn=""false"" IsPassive=""false""
                    ProtocolBinding=""urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST"" xmlns:samlp=""urn:oasis:names:tc:SAML:2.0:protocol""
                    IssueInstant=""{timestamp}"" Destination=""{authenticationUrl}"" AssertionConsumerServiceURL=""{applicationUrl}"">
                    <samlp:NameIDPolicy AllowCreate=""false"" />
                    <saml:Issuer xmlns:saml=""urn:oasis:names:tc:SAML:2.0:assertion"">{issuerUrl}</saml:Issuer>
                    </samlp:AuthnRequest>";
        }
    }
}