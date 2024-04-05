using Microsoft.AspNetCore.Components;

namespace Blazor_Eshop_Obligatorisk_Opgave.Client.Components
{
    public abstract class PageInfoModel : ComponentBase
    {
        [Parameter]
        public virtual string? Title { get; set; }

        [Parameter]
        public virtual string? Description { get; set; }
    }
}
