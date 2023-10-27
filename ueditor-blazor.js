// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API
window.UEditorBlazor = {
  // create UEditor instance
  createUEditor: function(domRef, editor, value, options = {}) {

    options = convertJsonKey(options);

    domRef.UEditor = UE.getEditor(domRef.id, options);
    domRef.UEditor.ready(function () {
        editor.invokeMethodAsync('HandleRendered');
        domRef.UEditor.setHeight(options.height);
    });
    domRef.UEditor.addListener('contentchange', function () {
      var content = domRef.UEditor.getContent();
      editor.invokeMethodAsync('HandleInput', content);
    });
  },
  getValue: function(domRef) {
    return domRef.UEditor.getContentTxt();
  },
  getHTML: function(domRef) {
    return domRef.UEditor.getContent();
  },
  setValue: function(domRef, value, append) {
    domRef.UEditor.setContent(value || "", append);
  },
  setHeight: function(domRef, value, stop) {
    domRef.UEditor.setHeight(value, stop);
  },
  destroy: function(domRef) {
    //domRef.UEditor.destroy();
  },
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