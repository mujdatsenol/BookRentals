using System.ComponentModel.DataAnnotations;

namespace BookRentals.Application.Abstractions
{
    public class RentBookRequest
    {
        [Required(ErrorMessage = "Kitab bilgisi boş olamaz")]
        public Guid BookId { get; set; }

        [Required(ErrorMessage = "Üye kimliğini giriniz")]
        public string IdentityNumber { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
