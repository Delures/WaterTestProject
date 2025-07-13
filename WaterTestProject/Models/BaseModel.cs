using CommunityToolkit.Mvvm.ComponentModel;

namespace WaterTestProject.Models;

public abstract partial class BaseModel : ObservableObject
{
    [ObservableProperty] private Guid _id = Guid.NewGuid();
    [ObservableProperty] private bool _deleted;
}