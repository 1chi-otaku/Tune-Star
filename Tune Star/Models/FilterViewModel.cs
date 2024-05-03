using Microsoft.AspNetCore.Mvc.Rendering;
using Tune_Star.BLL.DTO;

namespace Tune_Star.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<GenreDTO> genres, int genre, string position)
        {
            genres.Insert(0, new GenreDTO { Name = "All", Id = 0 });
            Genres = new SelectList(genres, "Id", "Name", genre);
            SelectedGenre = genre;
            SelectedPosition = position;
        }
        public SelectList Genres { get; }
        public int SelectedGenre { get; }
        public string SelectedPosition { get; }
    }
}
