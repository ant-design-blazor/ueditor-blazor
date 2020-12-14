// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API
window.UEditorBlazor = window.UEditorBlazor || {
  // create UEditor instance
  createUEditor: (domRef, editor, value, options = {}) => {
    options = convertJsonKey(options);

    domRef.UEditor = UE.getEditor(domRef, {
      ...options,
    });
    domRef.UEditor.ready(() => {
      editor.invokeMethodAsync('HandleRendered');
    });
    domRef.UEditor.addListener('contentchange', () => {
      var content = domRef.UEditor.getContent();
      editor.invokeMethodAsync('HandleInput', content);
    });
  },
  getValue: (domRef) => {
    return domRef.UEditor.getContentTxt();
  },
  getHTML: (domRef) => {
    return domRef.UEditor.getContent();
  },
  setValue: (domRef, value, append) => {
    domRef.UEditor.setContent(value, append);
  },
  // insertValue: (domRef, value, render = true) => {
  //   domRef.UEditor.insertValue(value, render);
  // },
  destroy: (domRef) => {
    domRef.UEditor.destroy();
  },
  // preview: (domRef, editor, markdown, options = {}) => {
  //   options = convertJsonKey(options);
  //   UEditor.preview(domRef, markdown, {
  //     ...options,
  //     after() {
  //       if (options.handleAfter) {
  //         editor.invokeMethodAsync('HandleAfter');
  //       }
  //     }
  //   });
  // }
}

var convertJsonKey = function (jsonObj) {
  var result = {};
  for (key in jsonObj) {
    var keyval = jsonObj[key];
    if (keyval == null) {
      continue;
    }
    key = key.replace(key[0], key[0].toLowerCase());
    result[key] = keyval;
  }
  return result;
}