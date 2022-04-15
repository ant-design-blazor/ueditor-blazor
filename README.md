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
        <script>
            window.NEDITOR_UPLOAD = "/api/upload";
        </script>
        <script src="_content/UEditorBlazor/neditor.config.js"></script>
        <script src="_content/UEditorBlazor/neditor.all.min.js" defer></script>
        <script src="_content/UEditorBlazor/ueditor-blazor.js"></script>
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
# Image Loading

If you want to implement custom image loading, follow the instructions listed below:

### 1. Setting the upload api endpoint:
```html
<script>
    window.NEDITOR_UPLOAD = "/api/upload";
</script>
```

In `neditor.service.js`, be sure in `getActionUrl` function, return `window.NEDITOR_UPLOAD`.

### 2. Image upload server implementing:

#### 2.1 Before adding an api controller, register some stuffs

```c#
services.AddControllers();
```

#### 2.2 Add a directory to store images

```c#
app.UseStaticFiles(new StaticFileOptions {
    FileProvider = new PhysicalFileProvider(image_path),
    RequestPath = "/I"
})
```

The `/I` suffix is used to show preview images. You can modify `image_path` and `/I` meantime in the controller.

#### 2.3 Write an api controller to process `/api/upload` request

See `ImageController.cs`. Remember the `root` and `result.url` variants should be the same as mentioned in `2.2`.

### 3. Enjoy.
