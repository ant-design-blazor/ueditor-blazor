# ueditor-blazor

A wysiwyg rich text web editor based on UEditor and Blazor.

# 💿 Current Version

- Release: [![UEditorBlazor](https://img.shields.io/nuget/v/UEditorBlazor.svg?color=red&style=flat-square)](https://www.nuget.org/packages/UEditorBlazor/)
- Development: [![UEditorBlazor](https://img.shields.io/nuget/vpre/UEditorBlazor.svg?color=red&style=flat-square)](https://www.nuget.org/packages/UEditorBlazor/)

# Usage

1. Install the package
    ```bash
      $ dotnet add package UEditorBlazor -v 0.1.0-*
    ```

2. Import js resources
    ```html
        <script src="_content/UEditor/neditor.config.js"></script>
        <script src="_content/UEditor/neditor.all.min.js" defer></script>
        <script src="_content/UEditor/ueditor-blazor.js"></script>
    ```

3. That's all! Then you can use the `UEditor.Editor` component.
    ```razor
    <UEditor.Editor @ref="editor" @bind-Value="value" @bind-Html="html" Height="500px" Width="700px" />
    
    @code {
        string value = "Hello Blazor!";
        string html;
    
        Editor editor;
    }
    ```
