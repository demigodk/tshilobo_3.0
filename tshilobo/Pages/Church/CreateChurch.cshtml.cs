using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace tshilobo.Pages.Church
{
    [Authorize]
    public class CreateChurchModel : PageModel
    {
        public string ReturnUrl { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string ChurchCode { get; set; }

            public bool HasBranches { get; set; }

            public bool IsMainBranch { get; set; }

            public string MissionStatement { get; set; }

            [Required]
            public string ChurchName { get; set; }

            public DateTime FoundingDate { get; set; }

            public string FounderName { get; set; }

            public string CreatorId { get; set; }

            public string VisionStatement { get; set; }

            public string Country { get; set; }

            public string Province { get; set; }

            public string City { get; set; }

            public string Street { get; set; }

            public string ChurchLeaderId { get; set; }

            public string MainBelief { get; set; }

            public int MainBranchId { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {           
                ReturnUrl = returnUrl;
        }

        //public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        //{
        //    returnUrl = returnUrl ?? Url.Content("~/");
        //}
    }
}
