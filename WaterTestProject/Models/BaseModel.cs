using CommunityToolkit.Mvvm.ComponentModel;

namespace WaterTestProject.Models;

public abstract partial class BaseModel : ObservableObject
{
    [ObservableProperty] private bool _deleted;
    [ObservableProperty] private Guid _id = Guid.NewGuid();
}