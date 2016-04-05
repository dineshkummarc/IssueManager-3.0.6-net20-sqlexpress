//JS Functions @0-B96B5E53
var isNN = (navigator.appName.indexOf("Netscape") != -1);
var isIE = (navigator.appName.indexOf("Microsoft") != -1);
var IEVersion = (isIE ? getIEVersion() : 0);
var NNVersion = (isNN ? getNNVersion() : 0);
var EditableGrid = false;
var disableValidation = false;

function parseParams(text,substitutions)
{
  // replace the {0}, ... with corresponded substitution string and return the result
  var resString = text;
  if (resString!="" && substitutions!=null)
  {
    var array = (typeof(substitutions)!="object")?(new Array(substitutions)):substitutions;
    var icount = array.length;
    for (var i=0; i<icount; i++) 
      resString = resString.replace("{"+i+"}", array[i]);
    delete array;
    array = null;
  }
  return resString;
}

function functionExists(functionName)
{
  var exists = true;
  try{
    exists = typeof(eval(functionName))=="function";
  }catch(e){
    exists = false;
  }
  return exists;
}

function ccsShowError(control, msg)
{
  alert(msg);
  control.focus();
  return false;
}

function getNNVersion()
{
  var userAgent = window.navigator.userAgent;
  var isMajor = parseInt(window.navigator.appVersion);
  var isMinor = parseFloat(window.navigator.appVersion);
  if (isMajor == 2) return 2;
  if (isMajor == 3) return 3;
  if (isMajor == 4) return 4;
  if (isMajor == 5) 
  {
    if (userAgent.toLowerCase().indexOf('netscape')!=-1)
    {
      isMajor = parseInt(userAgent.substr(userAgent.toLowerCase().indexOf('netscape')+9));
      if (isMajor>0) return isMajor;
    }
    if (userAgent.toLowerCase().indexOf('firefox')!=-1) return 7;
    return 6;
  }
  return isMajor;
}

function getIEVersion()
{
  var userAgent = window.navigator.userAgent;
  var MSIEPos = userAgent.indexOf("MSIE");
  return (MSIEPos > 0 ? parseInt(userAgent.substring(MSIEPos+5, userAgent.indexOf(".", MSIEPos))) : 0);
}

function inputMasking(evt)
{
  if (isIE && IEVersion > 4)
  {
    if (window.event.altKey) return false;
    if (window.event.ctrlKey) return false;
    if (typeof(this.ccsInputMask) == "string")
    {
      var mask = this.ccsInputMask;
      var keycode = window.event.keyCode;
      this.value = applyMask(keycode, mask, this.value);
    }
    return (window.event.keyCode==13?true:false);
  } else if (isNN && NNVersion<6)
  {
    if (evt.ALT_MASK) return false;
    if (evt.CONTROL_MASK) return false;
    if (typeof(this.ccsInputMask) == "string")
    {
      var mask = this.ccsInputMask;
      var keycode = evt.which;
      this.value = applyMask(keycode, mask, this.value);
    }
    return (evt.which==13?true:false);
  } else if (isNN && NNVersion==6)
  {
    if (evt.altKey) return false;
    if (evt.ctrlKey) return false;
    var cancelKey = evt.which < 32;
    if (typeof(this.ccsInputMask) == "string")
    {
      var mask = this.ccsInputMask;
      var keycode = evt.which;
      if (keycode >= 32)
        this.value = applyMask(keycode, mask, this.value);
    }
    return cancelKey;
  } else if (isNN && NNVersion==7)
  {
    if (evt.altKey) return false;
    if (evt.ctrlKey) return false;
    var cancelKey = evt.which==13;
    if (typeof(this.ccsInputMask) == "string")
    {
      var mask = this.ccsInputMask;
      var keycode = evt.which;
      cancelKey = keycode < 32;
      if (!cancelKey)
        this.value = applyMask(keycode, mask, this.value);
    }
    return cancelKey || evt.which==13;
  } else
    return true;
}

function applyMaskToValue(mask, value)
{
  var oldValue = String(value);
  var newValue = "";
  var icount = oldValue.length;
  for (var i=0; i<icount; i++)
  {
    newValue = applyMask(oldValue.charCodeAt(i), mask, newValue);
  }
  return newValue;
}

function applyMask(keycode, mask, value)
{
  var digit = (keycode >= 48 && keycode <= 57);
  var plus = (keycode == 43);
  var dash = (keycode == 45);
  var space = (keycode == 32);
  var uletter = (keycode >= 65 && keycode <= 90);
  var lletter = (keycode >= 97 && keycode <= 122);
  
  var pos = value.length;
  switch(mask.charAt(pos))
  {
    case "0":
      if (digit)
        value += String.fromCharCode(keycode);
      break;
    case "L":
      if (uletter || lletter)
        value += String.fromCharCode(keycode);
      break;
    default:
      var isMatchMask = (String.fromCharCode(keycode) == mask.charAt(pos));
      while (pos < mask.length && mask.charAt(pos) != "0" && mask.charAt(pos) != "L")
        value += mask.charAt(pos++);
      if (!isMatchMask && pos < mask.length)
        value = applyMask(keycode, mask, value);
  }  
  return value;
}

function validate_control(control)
{
/*
ccsCaption - string
ccsErrorMessage - string

ccsRequired - boolean
ccsMinLength - integer
ccsMaxLength - integer
ccsRegExp - string

ccsValidator - validation function

ccsInputMask - string
*/
  if (disableValidation) return true;
  var errorMessage = control.ccsErrorMessage;
  var customErrorMessage = (typeof(errorMessage) != "undefined");
   
  if (typeof(control.ccsRequired) == "boolean" && control.ccsRequired)
    if (control.value == "")
      return ccsShowError(control, customErrorMessage ? errorMessage :
        parseParams("{res:CCS_RequiredField}", control.ccsCaption));

  if (typeof(control.ccsMinLength) == "number")
    if (control.value != "" && control.value.length < parseInt(control.ccsMinLength))
      return ccsShowError(control, customErrorMessage ? errorMessage :
        parseParams("{res:CCS_MinimumLength}", Array(control.ccsCaption,parseInt(control.ccsMinLength))));

  if (typeof(control.ccsMaxLength) == "number")
    if (control.value != "" && control.value.length > parseInt(control.ccsMaxLength))
      return ccsShowError(control, customErrorMessage ? errorMessage :
        parseParams("{res:CCS_MaximumLength}", Array(control.ccsCaption,parseInt(control.ccsMaxLength))));

  if (typeof(control.ccsInputMask) == "string")
  {
    var mask = control.ccsInputMask;
    var maskRE = new RegExp(stringToRegExp(mask).replace(/0/g,"\\d").replace(/L/g,"[A-Za-z]"), "i");
    if (control.value != "" && (control.value.search(maskRE) == -1))
      return ccsShowError(control, customErrorMessage ? errorMessage :
        parseParams("{res:CCS_IncorrectValue}", control.ccsCaption));
  }

  if (typeof(control.ccsRegExp) == "string")
    if (control.value != "" && (control.value.search(new RegExp(control.ccsRegExp, "i")) == -1))
      return ccsShowError(control, customErrorMessage ? errorMessage :
        parseParams("{res:CCS_IncorrectValue}", control.ccsCaption));

  if (typeof(control.ccsDateFormat) == "string")
  {
    if (control.value != "" && !checkDate(control.value, control.ccsDateFormat))
      return ccsShowError(control, customErrorMessage ? errorMessage :
        parseParams("{res:CCS_IncorrectFormat}", Array(control.ccsCaption, control.ccsDateFormat)));
  }

  if (typeof(control.ccsValidator) == "function")
    if (!control.ccsValidator())
      return ccsShowError(control, customErrorMessage ? errorMessage :
        parseParams("{res:CCS_IncorrectValue}", control.ccsCaption));

  return true;
}


function stringToRegExp(string, arg)
{
  var str = String(string);
  str = str.replace(/\\/g,"\\\\");
  str = str.replace(/\//g,"\\/");
  str = str.replace(/\./g,"\\.");
  str = str.replace(/\(/g,"\\(");
  str = str.replace(/\)/g,"\\)");
  str = str.replace(/\[/g,"\\[");
  str = str.replace(/\]/g,"\\]");
  return str;
}

function checkDate(dateValue, dateFormat)
{
  var DateMasks = new Array(
                    new Array("MMMM", "[a-z]+"),
                    new Array("mmmm", "[a-z]+"),
                    new Array("yyyy", "[0-9]{4}"),
                    new Array("MMM", "[a-z]+"),
                    new Array("mmm", "[a-z]+"),
                    new Array("HH", "([0-1][0-9]|2[0-4])"),
                    new Array("hh", "(0[1-9]|1[0-2])"),
                    new Array("dd", "([0-2][0-9]|3[0-1])"),
                    new Array("MM", "(0[1-9]|1[0-2])"),
                    new Array("mm", "(0[1-9]|1[0-2])"),
                    new Array("yy", "[0-9]{2}"),
                    new Array("nn", "[0-5][0-9]"),
                    new Array("ss", "[0-5][0-9]"),
                    new Array("w", "[1-7]"),
                    new Array("d", "([1-9]|[1-2][0-9]|3[0-1])"),
                    new Array("y", "([1-2][0-9]{0,2}|3([0-5][0-9]|6[0-5]))"),
                    new Array("H", "(00|0?[1-9]|1[0-9]|2[0-4])"),
                    new Array("h", "(0?[1-9]|1[0-2])"),
                    new Array("M", "(0?[1-9]|1[0-2])"),
                    new Array("m", "(0?[1-9]|1[0-2])"),
                    new Array("n", "[0-5]?[0-9]"),
                    new Array("s", "[0-5]?[0-9]"),
                    new Array("q", "[1-4]")
                  );
  var regExp = "^"+stringToRegExp(dateFormat)+"$";
  var icount = DateMasks.length;
  for (var i=0; i<icount; i++)
  {
    regExp = regExp.replace(DateMasks[i][0], DateMasks[i][1]);
  }
  var regExp = new RegExp(regExp,"i");
  return String(dateValue).search(regExp)!=-1;
}

function validate_row(rowId, form)
{
  var result = true;
  var isInsert = false;
  if (disableValidation) return true;
  if(typeof(eval(form + "EmptyRows")) == "number")
    if(eval(form + "Elements").length - rowId <= eval(form + "EmptyRows"))
      isInsert = true;
  var icount = eval(form + "Elements")[rowId].length;
  for (var i = 0; i < icount && isInsert; i++)
    isInsert = GetValue(eval(form + "Elements")[rowId][i]) == "";
  if(isInsert) return true;

  if(typeof(eval(form + "DeleteControl")) == "number")
    {
      var control = eval(form + "Elements")[rowId][eval(form + "DeleteControl")];
      if(control.type == "checkbox")
        if(control.checked == true ) return true;
      if(control.type == "hidden")
        if(control.value != "" ) return true;
    }

  
  for (var i = 0; i < icount && (result = validate_control(eval(form + "Elements")[rowId][i])); i++);
  return result;
}

function GetValue(control) {
    if (typeof(control.value) == "string") {
        return control.value;
    }
    if (typeof(control.tagName) == "undefined" && typeof(control.length) == "number") {
        var j;
        var jcount = control.length;
        for (j=0; j < jcount; j++) {
            var inner = control[j];
            if (typeof(inner.value) == "string" && (inner.type != "radio" || inner.status == true)) {
                return inner.value;
            }
        }
    }
    else {
        return GetValueRecursive(control);
    }
    return "";
}

function GetValueRecursive(control)
{
    if (typeof(control.value) == "string" && (control.type != "radio" || control.status == true)) {
        return control.value;
    }
    var i, val;
    var icount = control.children.length;
    for (i = 0; i<icount; i++) {
        val = GetValueRecursive(control.children[i]);
        if (val != "") return val;
    }
    return "";
}


function validate_form(form)
{
  var result = true;
  if (disableValidation) return true;
  if(typeof(form) == "object" && String(form.tagName).toLowerCase()!="form" && form.form!=null) form = form.form;
  if(typeof(form) == "object" && document.getElementById(form.name + "Elements")) {
    if (typeof(eval(form.name + "Elements")) == "object") 
    {
      var jcount = eval(form.name + "Elements").length;
      for (var j = 0; j < jcount && result; j++) result = validate_row(j, form.name);
    }else
    {
      var icount = form.elements.length;
      for (var i = 0; i < icount && (result = validate_control(form.elements[i])); i++);
    }
  }else if(typeof(form) == "string" && document.getElementById(form.name + "Elements"))
  {
    if(typeof(eval(form + "Elements")) == "object"){
      var jcount = eval(form + "Elements").length;
      for (var j = 0; j < jcount && result; j++)
        result = validate_row(j, form);
    }
  }else if (typeof(form) == "object")
        {
          var icount = form.elements.length;
          for (var i = 0; i < icount && (result = validate_control(form.elements[i])); i++);
        }
        else
        {
          var icount = document.forms[form].elements.length;
          for (var i = 0; i < icount && (result = validate_control(document.forms[form].elements[i])); i++);
        }
  return result;
}

function forms_onload()
{
  var forms = document.forms;
  var i, j, elm, form;
  var icount = forms.length;
  var arrElementsOnLoad = new Array();

  for(i = 0; i < icount; i++)
  {
    form = forms[i];
    if (typeof(form.onLoad) == "function") form.onLoad();
    var jcount = form.elements.length;

    for (j = 0; j < jcount; j++)
    {
      elm = form.elements[j];
      if (typeof(elm.onLoad) == "function") arrElementsOnLoad[arrElementsOnLoad.length] = elm;
    }
  }

  for (i = 0; i < arrElementsOnLoad.length; i++)
	arrElementsOnLoad[i].onLoad();

  return true;
}


//
// If element exist than bind function func to element on event.
// Example: check_and_bind('document.NewRecord1.Delete1','onclick',page_NewRecord1_Delete1_OnClick);
//
function check_and_bind(element,event,func) {
  var htmlElement = eval(element);
  if (!htmlElement)
  {
    var index = element.lastIndexOf(".");
    var form = element.substr(0,index);
    var control = element.substr(index+1);
    var htmlForm = eval(form);
    if (htmlForm)
    {
      var list = document.getElementsByName(control);
      var icount = list.length;
      for (var i=0; i<icount; i++)
      {
        if (list[i].form && list[i].form.name==htmlForm.name)
        {
          eval("document.getElementsByName(\""+control+"\")["+i+'].'+event+'='+func);
        }
      }
    }
  }else{
    if (htmlElement) {
      if (typeof(htmlElement)=="object" && !htmlElement.tagName && htmlElement.length > 0)
      {
        var icount = htmlElement.length;
        for (var i=0; i < icount; i++)
          eval(element+"["+i+'].'+event+'='+func);
      }else eval(element+'.'+event+'='+func);
    }
  }
}



//End JS Functions

