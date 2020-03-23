
using EVSoft.Covid19.AppCovid19.Models;

namespace EVSoft.Covid19.AppCovid19.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
