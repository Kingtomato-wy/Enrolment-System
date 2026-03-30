using enrolmentSystem.Data;
using enrolmentSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace enrolmentSystem.Pages.Account
{
    public class UpdateProfileModel : PageModel
    {
        private readonly AppDbContext context;
        public UpdateProfileModel(AppDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public ProfileModel update { get; set; }

        public Student studentRecord { get; set; }

        public string StudentID { get; private set; }


        //List of Relationship
        public List<SelectListItem> Relationships { get; set; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "Father", Text = "Father" },
            new SelectListItem {Value = "Mother", Text = "Mother" },
            new SelectListItem {Value = "Guardian", Text = "Guardian" },
            new SelectListItem {Value = "Friend", Text = "Friend" },
            new SelectListItem {Value = "Relative", Text = "Relative" }
        };

        //List of Bank Name
        public List<SelectListItem> bankNames { get; set; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "ABB: Affin Bank Berhad", Text = "ABB: Affin Bank Berhad" },
            new SelectListItem { Value = "ABM : ALLIANCE BANK MALAYSIA", Text = "ABM : ALLIANCE BANK MALAYSIA" },
            new SelectListItem { Value = "AMB : AMBANK BERHAD", Text = "AMB : AMBANK BERHAD" },
            new SelectListItem { Value = "BBB : BANGKOK BANK BERHAD", Text = "BBB : BANGKOK BANK BERHAD" },
            new SelectListItem { Value = "BIMB : BANK ISLAM MALAYSIA BERHAD", Text = "BIMB : BANK ISLAM MALAYSIA BERHAD" },
            new SelectListItem { Value = "BMMB : BANK MUAMALAT MALAYSIA BERHAD", Text = "BMMB : BANK MUAMALAT MALAYSIA BERHAD" },
            new SelectListItem { Value = "BNS : THE BANK OF NOVA SCOTIA BERHAD", Text = "BNS : THE BANK OF NOVA SCOTIA BERHAD" },
            new SelectListItem { Value = "BR : BANK RAKYAT", Text = "BR : BANK RAKYAT" },
            new SelectListItem { Value = "BSNL : BANK SIMPANAN NASIONAL", Text = "BSNL : BANK SIMPANAN NASIONAL" },
            new SelectListItem { Value = "CIMB : CIMB BANK", Text = "CIMB : CIMB BANK" },
            new SelectListItem { Value = "CITI : CITIBANK", Text = "CITI : CITIBANK" },
            new SelectListItem { Value = "DBMB : DEUTSCHE BANK (MALAYSIA) BERHAD", Text = "DBMB : DEUTSCHE BANK (MALAYSIA) BERHAD" },
            new SelectListItem { Value = "HLB : HONG LEONG BANK BHD", Text = "HLB : HONG LEONG BANK BHD" },
            new SelectListItem { Value = "HSBC : HSBC BANK MALAYSIA BERHAD", Text = "HSBC : HSBC BANK MALAYSIA BERHAD" },
            new SelectListItem { Value = "IIB : INDIA INTERNATIONAL BANK MALAYSIA", Text = "IIB : INDIA INTERNATIONAL BANK MALAYSIA" },
            new SelectListItem { Value = "MBB : MAYBANK BERHAD", Text = "MBB : MAYBANK BERHAD" },
            new SelectListItem { Value = "OCBC : OCBC BANK MALAYSIA BERHAD", Text = "OCBC : OCBC BANK MALAYSIA BERHAD" },
            new SelectListItem { Value = "PBB : PUBLIC BANK BERHAD", Text = "PBB : PUBLIC BANK BERHAD" },
            new SelectListItem { Value = "RHB : RHB BANK BERHAD", Text = "RHB : RHB BANK BERHAD" },
            new SelectListItem { Value = "SCB : STANDARD CHARTERED BANK BERHAD", Text = "SCB : STANDARD CHARTERED BANK BERHAD" },
            new SelectListItem { Value = "UOB : UNITED OVERSEAS BANK", Text = "UOB : UNITED OVERSEAS BANK" }
        };

        //List of Country
        public List<SelectListItem> Countries { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Afghanistan", Text = "Afghanistan" },
            new SelectListItem { Value = "Albania", Text = "Albania" },
            new SelectListItem { Value = "Algeria", Text = "Algeria" },
            new SelectListItem { Value = "American Samoa", Text = "American Samoa" },
            new SelectListItem { Value = "Andorra", Text = "Andorra" },
            new SelectListItem { Value = "Angola", Text = "Angola" },
            new SelectListItem { Value = "Anguilla", Text = "Anguilla" },
            new SelectListItem { Value = "Antarctica", Text = "Antarctica" },
            new SelectListItem { Value = "Antigua and Barbuda", Text = "Antigua and Barbuda" },
            new SelectListItem { Value = "Argentina", Text = "Argentina" },
            new SelectListItem { Value = "Armenia", Text = "Armenia" },
            new SelectListItem { Value = "Aruba", Text = "Aruba" },
            new SelectListItem { Value = "Australia", Text = "Australia" },
            new SelectListItem { Value = "Austria", Text = "Austria" },
            new SelectListItem { Value = "Azerbaijan", Text = "Azerbaijan" },
            new SelectListItem { Value = "Bahamas", Text = "Bahamas" },
            new SelectListItem { Value = "Bahrain", Text = "Bahrain" },
            new SelectListItem { Value = "Bangladesh", Text = "Bangladesh" },
            new SelectListItem { Value = "Barbados", Text = "Barbados" },
            new SelectListItem { Value = "Belarus", Text = "Belarus" },
            new SelectListItem { Value = "Belgium", Text = "Belgium" },
            new SelectListItem { Value = "Belize", Text = "Belize" },
            new SelectListItem { Value = "Benin", Text = "Benin" },
            new SelectListItem { Value = "Bermuda", Text = "Bermuda" },
            new SelectListItem { Value = "Bhutan", Text = "Bhutan" },
            new SelectListItem { Value = "Bolivia", Text = "Bolivia" },
            new SelectListItem { Value = "Bosnia and Herzegovina", Text = "Bosnia and Herzegovina" },
            new SelectListItem { Value = "Botswana", Text = "Botswana" },
            new SelectListItem { Value = "Bouvet Island", Text = "Bouvet Island" },
            new SelectListItem { Value = "Brazil", Text = "Brazil" },
            new SelectListItem { Value = "British Dep Terr Citizen - BDTC,BTC", Text = "British Dep Terr Citizen - BDTC,BTC" },
            new SelectListItem { Value = "British Indian Ocean Territory", Text = "British Indian Ocean Territory" },
            new SelectListItem { Value = "British National Overseas - BNO", Text = "British National Overseas - BNO" },
            new SelectListItem { Value = "British Overseas Citizen - BOC,BO", Text = "British Overseas Citizen - BOC,BO" },
            new SelectListItem { Value = "British Protected Pers - BP", Text = "British Protected Pers - BP" },
            new SelectListItem { Value = "British Subject", Text = "British Subject" },
            new SelectListItem { Value = "Brunei", Text = "Brunei" },
            new SelectListItem { Value = "Bulgaria", Text = "Bulgaria" },
            new SelectListItem { Value = "Burkina Faso", Text = "Burkina Faso" },
            new SelectListItem { Value = "Burundi", Text = "Burundi" },
            new SelectListItem { Value = "Cambodia", Text = "Cambodia" },
            new SelectListItem { Value = "Cameroon", Text = "Cameroon" },
            new SelectListItem { Value = "Canada", Text = "Canada" },
            new SelectListItem { Value = "Cap_island + Atlanta", Text = "Cap_island + Atlanta" },
            new SelectListItem { Value = "Cape Verde", Text = "Cape Verde" },
            new SelectListItem { Value = "Caymanian", Text = "Caymanian" },
            new SelectListItem { Value = "Central African Republic", Text = "Central African Republic" },
            new SelectListItem { Value = "Chad", Text = "Chad" },
            new SelectListItem { Value = "Chile", Text = "Chile" },
            new SelectListItem { Value = "China", Text = "China" },
            new SelectListItem { Value = "Christmas Island", Text = "Christmas Island" },
            new SelectListItem { Value = "Cocos Islands", Text = "Cocos Islands" },
            new SelectListItem { Value = "Colombia", Text = "Colombia" },
            new SelectListItem { Value = "Comoros", Text = "Comoros" },
            new SelectListItem { Value = "Congo", Text = "Congo" },
            new SelectListItem { Value = "Cook Islands", Text = "Cook Islands" },
            new SelectListItem { Value = "Costa Rica", Text = "Costa Rica" },
            new SelectListItem { Value = "Cote d'Ivoire", Text = "Cote d'Ivoire" },
            new SelectListItem { Value = "Croatia", Text = "Croatia" },
            new SelectListItem { Value = "Cuba", Text = "Cuba" },
            new SelectListItem { Value = "Cypriot", Text = "Cypriot" },
            new SelectListItem { Value = "Czech Republic", Text = "Czech Republic" },
            new SelectListItem { Value = "Denmark", Text = "Denmark" },
            new SelectListItem { Value = "Djibouti", Text = "Djibouti" },
            new SelectListItem { Value = "Dominica", Text = "Dominica" },
            new SelectListItem { Value = "Dominican Republic", Text = "Dominican Republic" },
            new SelectListItem { Value = "Ecuador", Text = "Ecuador" },
            new SelectListItem { Value = "Egypt", Text = "Egypt" },
            new SelectListItem { Value = "El Salvador", Text = "El Salvador" },
            new SelectListItem { Value = "Equatorial Guinea", Text = "Equatorial Guinea" },
            new SelectListItem { Value = "Eritrea", Text = "Eritrea" },
            new SelectListItem { Value = "Estonia", Text = "Estonia" },
            new SelectListItem { Value = "Ethiopia", Text = "Ethiopia" },
            new SelectListItem { Value = "Falkland Islands", Text = "Falkland Islands" },
            new SelectListItem { Value = "Faroe Islands", Text = "Faroe Islands" },
            new SelectListItem { Value = "Fiji", Text = "Fiji" },
            new SelectListItem { Value = "Finland", Text = "Finland" },
            new SelectListItem { Value = "France", Text = "France" },
            new SelectListItem { Value = "French Guiana", Text = "French Guiana" },
            new SelectListItem { Value = "French Polynesia", Text = "French Polynesia" },
            new SelectListItem { Value = "French Southern Territories", Text = "French Southern Territories" },
            new SelectListItem { Value = "Gabon", Text = "Gabon" },
            new SelectListItem { Value = "Gambia", Text = "Gambia" },
            new SelectListItem { Value = "Georgia", Text = "Georgia" },
            new SelectListItem { Value = "Germany", Text = "Germany" },
            new SelectListItem { Value = "Ghana", Text = "Ghana" },
            new SelectListItem { Value = "Gibraltar", Text = "Gibraltar" },
            new SelectListItem { Value = "Greece", Text = "Greece" },
            new SelectListItem { Value = "Greenland", Text = "Greenland" },
            new SelectListItem { Value = "Grenada", Text = "Grenada" },
            new SelectListItem { Value = "Guadeloupe", Text = "Guadeloupe" },
            new SelectListItem { Value = "Guam", Text = "Guam" },
            new SelectListItem { Value = "Guatemala", Text = "Guatemala" },
            new SelectListItem { Value = "Guinea", Text = "Guinea" },
            new SelectListItem { Value = "Guinea-Bissau", Text = "Guinea-Bissau" },
            new SelectListItem { Value = "Guyana", Text = "Guyana" },
            new SelectListItem { Value = "Haiti", Text = "Haiti" },
            new SelectListItem { Value = "Heard and McDonald Islands", Text = "Heard and McDonald Islands" },
            new SelectListItem { Value = "Vatican City", Text = "Vatican City" },
            new SelectListItem { Value = "Honduras", Text = "Honduras" },
            new SelectListItem { Value = "Hong Kong", Text = "Hong Kong" },
            new SelectListItem { Value = "Hungary", Text = "Hungary" },
            new SelectListItem { Value = "Iceland", Text = "Iceland" },
            new SelectListItem { Value = "India", Text = "India" },
            new SelectListItem { Value = "Indonesia", Text = "Indonesia" },
            new SelectListItem { Value = "Iran", Text = "Iran" },
            new SelectListItem { Value = "Iraq", Text = "Iraq" },
            new SelectListItem { Value = "Ireland", Text = "Ireland" },
            new SelectListItem { Value = "Israel", Text = "Israel" },
            new SelectListItem { Value = "Italy", Text = "Italy" },
            new SelectListItem { Value = "Jamaica", Text = "Jamaica" },
            new SelectListItem { Value = "Japan", Text = "Japan" },
            new SelectListItem { Value = "Jordan", Text = "Jordan" },
            new SelectListItem { Value = "Kazakhstan", Text = "Kazakhstan" },
            new SelectListItem { Value = "Kenya", Text = "Kenya" },
            new SelectListItem { Value = "Kiribati", Text = "Kiribati" },
            new SelectListItem { Value = "South Korea", Text = "South Korea" },
            new SelectListItem { Value = "North Korea", Text = "North Korea" },
            new SelectListItem { Value = "Kuwait", Text = "Kuwait" },
            new SelectListItem { Value = "Kyrgyzstan", Text = "Kyrgyzstan" },
            new SelectListItem { Value = "Laos", Text = "Laos" },
            new SelectListItem { Value = "Latvia", Text = "Latvia" },
            new SelectListItem { Value = "Lebanon", Text = "Lebanon" },
            new SelectListItem { Value = "Lesotho", Text = "Lesotho" },
            new SelectListItem { Value = "Liberia", Text = "Liberia" },
            new SelectListItem { Value = "Libya", Text = "Libya" },
            new SelectListItem { Value = "Liechtenstein", Text = "Liechtenstein" },
            new SelectListItem { Value = "Lithuania", Text = "Lithuania" },
            new SelectListItem { Value = "Luxembourg", Text = "Luxembourg" },
            new SelectListItem { Value = "Macau", Text = "Macau" },
			//new SelectListItem { Value = "Malaysia", Text = "Malaysia", Selected = true },
			new SelectListItem { Value = "Malaysia", Text = "Malaysia" },
            new SelectListItem { Value = "Maldives", Text = "Maldives" },
            new SelectListItem { Value = "Mali", Text = "Mali" },
            new SelectListItem { Value = "Malta", Text = "Malta" },
            new SelectListItem { Value = "Marshall Islands", Text = "Marshall Islands" },
            new SelectListItem { Value = "Mauritania", Text = "Mauritania" },
            new SelectListItem { Value = "Mauritius", Text = "Mauritius" },
            new SelectListItem { Value = "Mexico", Text = "Mexico" },
            new SelectListItem { Value = "Micronesia", Text = "Micronesia" },
            new SelectListItem { Value = "Moldova", Text = "Moldova" },
            new SelectListItem { Value = "Monaco", Text = "Monaco" },
            new SelectListItem { Value = "Mongolia", Text = "Mongolia" },
            new SelectListItem { Value = "Montenegro", Text = "Montenegro" },
            new SelectListItem { Value = "Morocco", Text = "Morocco" },
            new SelectListItem { Value = "Mozambique", Text = "Mozambique" },
            new SelectListItem { Value = "Myanmar", Text = "Myanmar" },
            new SelectListItem { Value = "Namibia", Text = "Namibia" },
            new SelectListItem { Value = "Nauru", Text = "Nauru" },
            new SelectListItem { Value = "Nepal", Text = "Nepal" },
            new SelectListItem { Value = "Netherlands Antilles", Text = "Netherlands Antilles" },
            new SelectListItem { Value = "New Caledonia", Text = "New Caledonia" },
            new SelectListItem { Value = "New Zealand", Text = "New Zealand" },
            new SelectListItem { Value = "Nicaragua", Text = "Nicaragua" },
            new SelectListItem { Value = "Niger", Text = "Niger" },
            new SelectListItem { Value = "Nigeria", Text = "Nigeria" },
            new SelectListItem { Value = "Niue", Text = "Niue" },
            new SelectListItem { Value = "Non-S Pore Citizen", Text = "Non-S Pore Citizen" },
            new SelectListItem { Value = "Norfolk Island", Text = "Norfolk Island" },
            new SelectListItem { Value = "Northern Mariana Islands", Text = "Northern Mariana Islands" },
            new SelectListItem { Value = "Norway", Text = "Norway" },
            new SelectListItem { Value = "Oman", Text = "Oman" },
            new SelectListItem { Value = "Pacific Isl Trust Terr/Palau", Text = "Pacific Isl Trust Terr/Palau" },
            new SelectListItem { Value = "Pakistan", Text = "Pakistan" },
            new SelectListItem { Value = "Palau", Text = "Palau" },
            new SelectListItem { Value = "Palestine", Text = "Palestine" },
            new SelectListItem { Value = "Panama", Text = "Panama" },
            new SelectListItem { Value = "Papua New Guinea", Text = "Papua New Guinea" },
            new SelectListItem { Value = "Paraguay", Text = "Paraguay" },
            new SelectListItem { Value = "Peru", Text = "Peru" },
            new SelectListItem { Value = "Philippines", Text = "Philippines" },
            new SelectListItem { Value = "Pitcairn", Text = "Pitcairn" },
            new SelectListItem { Value = "Poland", Text = "Poland" },
            new SelectListItem { Value = "Portugal", Text = "Portugal" },
            new SelectListItem { Value = "Puerto Rico", Text = "Puerto Rico" },
            new SelectListItem { Value = "Qatar", Text = "Qatar" },
            new SelectListItem { Value = "Republic Of Kosovo", Text = "Republic Of Kosovo" },
            new SelectListItem { Value = "Reunion", Text = "Reunion" },
            new SelectListItem { Value = "Romania", Text = "Romania" },
            new SelectListItem { Value = "Russia", Text = "Russia" },
            new SelectListItem { Value = "Rwanda", Text = "Rwanda" },
            new SelectListItem { Value = "Saint Kitts And Nevis", Text = "Saint Kitts And Nevis" },
            new SelectListItem { Value = "Saint Lucia", Text = "Saint Lucia" },
            new SelectListItem { Value = "Saint Vincent And The Grenadines", Text = "Saint Vincent And The Grenadines" },
            new SelectListItem { Value = "Samoa", Text = "Samoa" },
            new SelectListItem { Value = "San Marino", Text = "San Marino" },
            new SelectListItem { Value = "Sao Tome And Principe", Text = "Sao Tome And Principe" },
            new SelectListItem { Value = "Saudi Arabia", Text = "Saudi Arabia" },
            new SelectListItem { Value = "Senegal", Text = "Senegal" },
            new SelectListItem { Value = "Seychelles", Text = "Seychelles" },
            new SelectListItem { Value = "Sierra Leone", Text = "Sierra Leone" },
            new SelectListItem { Value = "Singapore", Text = "Singapore" },
            new SelectListItem { Value = "Slovakia", Text = "Slovakia" },
            new SelectListItem { Value = "Slovenia", Text = "Slovenia" },
            new SelectListItem { Value = "Solomon Islands", Text = "Solomon Islands" },
            new SelectListItem { Value = "Somalia", Text = "Somalia" },
            new SelectListItem { Value = "South Africa", Text = "South Africa" },
            new SelectListItem { Value = "South Georgia And The South Sandwich Islands", Text = "South Georgia And The South Sandwich Islands" },
            new SelectListItem { Value = "South Korea", Text = "South Korea" },
            new SelectListItem { Value = "South Yemen", Text = "South Yemen" },
            new SelectListItem { Value = "Spain", Text = "Spain" },
            new SelectListItem { Value = "Sri Lanka", Text = "Sri Lanka" },
            new SelectListItem { Value = "St. Helena", Text = "St. Helena" },
            new SelectListItem { Value = "St. Pierre And Miquelon", Text = "St. Pierre And Miquelon" },
            new SelectListItem { Value = "Stateless", Text = "Stateless" },
            new SelectListItem { Value = "Sudan", Text = "Sudan" },
            new SelectListItem { Value = "Suriname", Text = "Suriname" },
            new SelectListItem { Value = "Svalbard And Jan Mayen Islands", Text = "Svalbard And Jan Mayen Islands" },
            new SelectListItem { Value = "Swaziland", Text = "Swaziland" },
            new SelectListItem { Value = "Sweden", Text = "Sweden" },
            new SelectListItem { Value = "Switzerland", Text = "Switzerland" },
            new SelectListItem { Value = "Syria", Text = "Syria" },
            new SelectListItem { Value = "Taiwan", Text = "Taiwan" },
            new SelectListItem { Value = "Tajikistan", Text = "Tajikistan" },
            new SelectListItem { Value = "Tanzania", Text = "Tanzania" },
            new SelectListItem { Value = "Thailand", Text = "Thailand" },
            new SelectListItem { Value = "The Netherlands", Text = "The Netherlands" },
            new SelectListItem { Value = "Timor", Text = "Timor" },
            new SelectListItem { Value = "Togo", Text = "Togo" },
            new SelectListItem { Value = "Tokelau", Text = "Tokelau" },
            new SelectListItem { Value = "Tonga", Text = "Tonga" },
            new SelectListItem { Value = "Trinidad And Tobago", Text = "Trinidad And Tobago" },
            new SelectListItem { Value = "Tunisia", Text = "Tunisia" },
            new SelectListItem { Value = "Turkey", Text = "Turkey" },
            new SelectListItem { Value = "Turkmenistan", Text = "Turkmenistan" },
            new SelectListItem { Value = "Turks And Caicos Islands", Text = "Turks And Caicos Islands" },
            new SelectListItem { Value = "Tuvalu", Text = "Tuvalu" },
            new SelectListItem { Value = "Uganda", Text = "Uganda" },
            new SelectListItem { Value = "Ukraine", Text = "Ukraine" },
            new SelectListItem { Value = "United Arab Emirates", Text = "United Arab Emirates" },
            new SelectListItem { Value = "United states minor outlying islands", Text = "United states Minor Outlying Islands" },
            new SelectListItem { Value = "United states of america", Text = "United States of America" },
            new SelectListItem { Value = "Upper volta", Text = "UpperVvolta" },
            new SelectListItem { Value = "Uruguay", Text = "Uruguay" },
            new SelectListItem { Value = "Uzbekistan", Text = "Uzbekistan" },
            new SelectListItem { Value = "Vanuatu", Text = "Vanuatu" },
            new SelectListItem { Value = "Venezuela", Text = "Venezuela" },
            new SelectListItem { Value = "Vietnam", Text = "Vietnam" },
            new SelectListItem { Value = "Virgin islands (british)", Text = "Virgin Islands (British)" },
            new SelectListItem { Value = "Virgin islands (us)", Text = "Virgin Islands (US)" },
            new SelectListItem { Value = "Wallis and futuna islands", Text = "Wallis and Futuna Islands" },
            new SelectListItem { Value = "Western sahara", Text = "Western Sahara" },
            new SelectListItem { Value = "Yemen", Text = "Yemen" },
            new SelectListItem { Value = "Yemen arab republic", Text = "Yemen Arab Republic" },
            new SelectListItem { Value = "Yugoslavia", Text = "Yugoslavia" },
            new SelectListItem { Value = "Zaire", Text = "Zaire" },
            new SelectListItem { Value = "Zambia", Text = "Zambia" },
            new SelectListItem { Value = "Zimbabwe", Text = "Zimbabwe" }
        };

        public async Task OnGetAsync()
        {
            StudentID = HttpContext.Session.GetString("StudentID"); //Get StudentID from session
            studentRecord = await context.Student.FirstOrDefaultAsync(s => s.studentID == StudentID); //Store student record

            update = new ProfileModel
            {
                TelNum = studentRecord.TelNum,
                HPNum = studentRecord.HPNum,
                primaryEmail = studentRecord.primaryEmail,
                alternativeEmail = studentRecord.alternativeEmail,
                permanantAddress = studentRecord.permanantAddress,
                permanantPostalCode = studentRecord.permanantPostalCode,
                permanantArea = studentRecord.permanantArea,
                permanantState = studentRecord.permanantState,
                permanantCountry = studentRecord.permanantCountry,
                currentAddress = studentRecord.currentAddress,
                currentPostalCode = studentRecord.currentPostalCode,
                currentArea = studentRecord.currentArea,
                currentState = studentRecord.currentState,
                currentCountry = studentRecord.currentCountry,
                emergencyContactRelationship = studentRecord.emergencyContactRelationship,
                emergencyContactName = studentRecord.emergencyContactName,
                emergencyHPNum = studentRecord.emergencyHPNum,
                bankName = studentRecord.bankName,
                bankAccountNumber = studentRecord.bankAccountNumber,
                bankHolderName = studentRecord.bankHolderName,
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //Check error in console
                foreach (var entry in ModelState)
                {
                    if (entry.Value.Errors.Count > 0)
                    {
                        Console.WriteLine($"Property: {entry.Key}");
                        foreach (var error in entry.Value.Errors)
                        {
                            Console.WriteLine($"- Error: {error.ErrorMessage}");
                        }
                    }
                }
                return Page();
            }

            StudentID = HttpContext.Session.GetString("StudentID"); //Get StudentID from session
            var studentRecord = await context.Student.FirstOrDefaultAsync(s => s.studentID == StudentID); //Store student record

            if (studentRecord == null)
            {
                //Check error in console
                foreach (var entry in ModelState)
                {
                    if (entry.Value.Errors.Count > 0)
                    {
                        Console.WriteLine($"Property: {entry.Key}");
                        foreach (var error in entry.Value.Errors)
                        {
                            Console.WriteLine($"- Error: {error.ErrorMessage}");
                        }
                    }
                }
                return Page();
            }

            studentRecord.TelNum = update.TelNum;
            studentRecord.HPNum = update.HPNum;
            studentRecord.primaryEmail = update.primaryEmail;
            studentRecord.alternativeEmail = update.alternativeEmail;
            studentRecord.permanantAddress = update.permanantAddress;
            studentRecord.permanantPostalCode = update.permanantPostalCode;
            studentRecord.permanantArea = update.permanantArea;
            studentRecord.permanantState = update.permanantState;
            studentRecord.permanantCountry = update.permanantCountry;
            studentRecord.currentAddress = update.currentAddress;
            studentRecord.currentPostalCode = update.currentPostalCode;
            studentRecord.currentArea = update.currentArea;
            studentRecord.currentState = update.currentState;
            studentRecord.currentCountry = update.currentCountry;
            studentRecord.emergencyContactRelationship = update.emergencyContactRelationship;
            studentRecord.emergencyContactName = update.emergencyContactName;
            studentRecord.emergencyHPNum = update.emergencyHPNum;
            studentRecord.bankName = update.bankName;
            studentRecord.bankAccountNumber = update.bankAccountNumber;
            studentRecord.bankHolderName = update.bankHolderName;

            try
            {
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Profile updated successfully!";
                return RedirectToPage("/StudentDashboard");
            }
            catch (DbUpdateException ex)
            {
                //Check error in console
                Console.WriteLine($"Error saving to database: {ex.Message}");
                return Page();
            }
        }
    }
}
