using Microsoft.AspNetCore.Mvc.Rendering;

/// <summary>
/// Author      :       Bondo Kalombo   
/// Date        :       16/11/2018
/// </summary>
namespace tshilobo.Data.Services.AuthenticationRelated
{
    public interface IListItem
    {
        SelectList GetGenderAsync();
        SelectList GetDayAsync();
        SelectList GetMonthAsync();
        SelectList GetYearAsync();
    }
}
