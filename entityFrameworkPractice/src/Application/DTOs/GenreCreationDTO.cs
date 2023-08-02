using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace entityFrameworkPractice.src.Application.DTOs
{
    public class GenreCreationDTO
    {
        [StringLength(maximumLength: 150)]
        public string Name { get; set; } = null!;
    }
}
