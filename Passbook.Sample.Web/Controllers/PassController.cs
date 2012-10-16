﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Passbook.Generator;
using Passbook.Generator.Fields;
using Passbook.Sample.Web.Requests;

namespace Passbook.Sample.Web.Controllers
{
    public class PassController : Controller
    {
        public ActionResult EventTicket()
        {
            PassGenerator generator = new PassGenerator();

            EventPassGeneratorRequest request = new EventPassGeneratorRequest();
            request.Identifier = "pass.tomsamcguinness.events";
            request.CertThumbprint = ConfigurationManager.AppSettings["PassBookCertificateThumbprint"];
            request.CertLocation = System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine;
            request.FormatVersion = 1;
            request.SerialNumber = "121211";
            request.Description = "My first pass";
            request.OrganizationName = "Tomas McGuinness";
            request.TeamIdentifier = "R5QS56362W";
            request.LogoText = "My Pass";
            request.BackgroundColor = "#FFFFFF";
            request.ForegroundColor = "#000000";

            request.BackgroundFile = Server.MapPath(@"~/Icons/Starbucks/background.png");
            request.BackgroundRetinaFile = Server.MapPath(@"~/Icons/Starbucks/background@2x.png");

            request.IconFile = Server.MapPath(@"~/Icons/icon.png");
            request.IconRetinaFile = Server.MapPath(@"~/Icons/icon@2x.png");

            request.LogoFile = Server.MapPath(@"~/Icons/logo.png");
            request.LogoRetinaFile = Server.MapPath(@"~/Icons/logo@2x.png");

            request.EventName = "Jeff Wayne's War of the Worlds";
            request.SeatingSection = 10;
            request.DoorsOpen = new DateTime(2012, 10, 08, 11, 30, 00);

            request.AddLocation(new LocationField() { Latitude = 51.488699, Longitude = -0.020213, ReleventText = "You're at Stratford" });

            request.AddBarCode("01927847623423234234", BarcodeType.PKBarcodeFormatPDF417, "UTF-8", "01927847623423234234");

            Pass generatedPass = generator.Generate(request);

            return new FileContentResult(generatedPass.GetPackage(), "application/vnd.apple.pkpass");
        }

        public ActionResult BoardingCard()
        {
            PassGenerator generator = new PassGenerator();

            BoardingCardGeneratorRequest request = new BoardingCardGeneratorRequest();
            request.Identifier = "pass.tomsamcguinness.events";
            request.CertThumbprint = ConfigurationManager.AppSettings["PassBookCertificateThumbprint"];
            request.CertLocation = System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine;
            request.FormatVersion = 1;
            request.SerialNumber = "121212111";
            request.Description = "My first pass";
            request.OrganizationName = "Tomas McGuinness";
            request.TeamIdentifier = "R5QS56362W";
            request.LogoText = "My Pass";
            request.BackgroundColor = "#000000";
            request.ForegroundColor = "#FFFFFF";

            request.BackgroundFile = Server.MapPath(@"~/Icons/Starbucks/background.png");
            request.BackgroundRetinaFile = Server.MapPath(@"~/Icons/Starbucks/background@2x.png");

            request.IconFile = Server.MapPath(@"~/Icons/Starbucks/icon.png");
            request.IconRetinaFile = Server.MapPath(@"~/Icons/Starbucks/icon@2x.png");

            request.LogoFile = Server.MapPath(@"~/Icons/Starbucks/logo.png");
            request.LogoRetinaFile = Server.MapPath(@"~/Icons/Starbucks/logo@2x.png");

            // Specific information
            //
            request.Origin = "San Francisco";
            request.OriginCode = "SFO";

            request.Destination = "London";
            request.DestinationCode = "LDN";

            request.Seat = "7A";
            request.BoardingGate = "F12";
            request.PassengerName = "John Appleseed";

            request.TransitType = TransitType.PKTransitTypeAir;

            request.AuthenticationToken = "vxwxd7J8AlNNFPS8k0a0FfUFtq0ewzFdc";
            request.WebServiceUrl = "http://192.168.1.59:82/api/";

            Pass generatedPass = generator.Generate(request);
            return new FileContentResult(generatedPass.GetPackage(), "application/vnd.apple.pkpass");
        }
    }
}
