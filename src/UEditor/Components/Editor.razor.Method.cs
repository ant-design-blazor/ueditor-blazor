using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace UEditor
{
    public partial class Editor : ComponentBase
    {
        [Inject] private IJSRuntime Js { get; set; }

        public async Task CreateUEditor()
        {
            await Js.InvokeVoidAsync("UEditorBlazor.createUEditor", _ref, DotNetObjectReference.Create(this), this.Value, this.Options);
        }

        public ValueTask<string> GetValue()
        {
            return Js.InvokeAsync<string>("UEditorBlazor.getValue", _ref);
        }

        public ValueTask<string> GetHTML()
        {
            return Js.InvokeAsync<string>("UEditorBlazor.getHTML", _ref);
        }

        public async Task SetValue(string value, bool clearStack = false)
        {
            await Js.InvokeVoidAsync("UEditorBlazor.setValue", _ref, value, clearStack);
        }

        public async Task InsertValue(string value, bool render = true)
        {
            await Js.InvokeVoidAsync("UEditorBlazor.setValue", _ref, value, render);
        }

        public async Task Destroy()
        {
            await Js.InvokeVoidAsync("UEditorBlazor.destroy", _ref);
        }

        public async Task SetHeight(string value, bool stop = false) {
            await Js.InvokeVoidAsync("UEditorBlazor.setHeight", _ref, value, stop);
        }
    }
}