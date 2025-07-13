using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WaterTestProject.Database.Models;
using WaterTestProject.Models;
using WaterTestProject.Services.DbServices;

namespace WaterTestProject.ViewModels;

public abstract partial class BaseViewModel<TDbModel, TModel> : ObservableObject
    where TDbModel : DbEntity
    where TModel : BaseModel, new()
{
    [ObservableProperty] private ObservableCollection<TModel> _collection = [];

    [ObservableProperty] private TModel? _selectedElement;
    private readonly CrudDbService<TDbModel, TModel> _orderDbService;

    protected BaseViewModel(CrudDbService<TDbModel, TModel> orderDbService)
    {
        _orderDbService = orderDbService;
        Collection = new ObservableCollection<TModel>(_orderDbService.ReadAll().ToList());
    }

    [RelayCommand]
    private void Add()
    {
        var model = new TModel();
        Collection.Add(model);
    }

    [RelayCommand]
    private async Task Remove()
    {
        if (SelectedElement != null)
        {
            await _orderDbService.DeleteAsync(SelectedElement);
            Collection.Remove(SelectedElement);
        }
    }

    [RelayCommand]
    private async Task Save()
    {
        await _orderDbService.SaveAll(Collection);
    }
}