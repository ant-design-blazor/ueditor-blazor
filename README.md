# ueditor-blazor

A wysiwyg rich text Web editor based on UEditor and Blazor.

# Usage

1. Install the package
    ```bash
      $ dotnet add package UEditor
    ```

2. Import js resources
    ```html
        <script src="_content/UEditor/neditor.config.js"></script>
        <script src="_content/UEditor/neditor.all.min.js" defer></script>
        <script src="_content/UEditor/ueditor-blazor.js"></script>
    ```

3. That's all! Then you can use the `UEditor.Editor` component.
    ```razor
    <UEditor.Editor @ref="editor" @bind-Value="value" @bind-Html="html" Height="500" MinHeight="500" />
    
    @code {
        string value = "Hello Blazor!";
        string html;
    
        Editor editor;
    }
    ```