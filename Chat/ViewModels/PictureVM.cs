using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Chat.Controllers
{
    public class PictureVM
    {
        [Required]
        public HttpPostedFileWrapper Picture { get; set; }
    }
}