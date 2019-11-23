/**
 * @version $Id: core.js 15814 2008-02-04 05:24:22Z lmurphy $
 * @package vx
 * @package $Name: HEAD $
 */

/* Global Variables */
var isSafari = false;
var isMoz = false;
var isIE = false;
var __currenttab = '';
var __currentwindow;
var __currentindex;
var isOver = false;

var ajaxRequestsInProgress = 0;

if (navigator.userAgent.indexOf("Safari") > 0) {
    isSafari = true;
} else if (navigator.product == "Gecko") {
    isMoz = true;
} else {
    isIE = true;
}

function displayClauselist(anchor, clausebox, trget) {
    try {
        currentbox = clausebox;


        __currentindex++;
        clausebox.style.zIndex = __currentindex;

        popup(clausebox, anchor);
        trget.focus();

        //Add to active box array if not been added
        if (!active_boxes[clausebox.id]) {
            active_boxes[clausebox.id] = clausebox;
        }
        clausebox.onmouseover = new Function("isOver = true");
        clausebox.onmouseout = new Function("isOver = false;");
        document.onclick = new Function("document.onclick = new Function(\"hideActiveBoxes('"+clausebox.id+"');\");");
    }
    catch (e) {
        alert(e);
    }
}

function hideClauselist(clausebox) {
    clausebox.style.display = 'none';
}

function loadFrame(name, src, height, width) {

    if (gbid(name) && gbid(name + 'Container')) {
        if (gbid(name + 'Loader')) {
            Effect.Appear(name + 'Loader');
        }

        gbid(name + 'Container').removeChild(gbid(name));
    }


    if (Ajax.activeRequestCount > 0) {
        setTimeout("loadFrame('" + name + "','" + src + "','" + height + "','" + width + "')", 100);
        return;
    }

    actuallyLoadFrame(name, src, height, width);

}

function actuallyLoadFrame(name, src, height, width) {

    if (!width) {
        width = '95%';
    }

    if (!height) {
        height = '100%';
    }

    var i, anon;

    i = document.createElement('IFRAME');
    i.src = src;
    i.scrolling = 'auto';
    i.style.backgroundColor = 'white';
    i.style.display = 'none';
    i.width = width;
    i.height = height;
    i.style.border = 0;
    i.frameBorder = 0;

    i.id = name;

    i.tabindex = 500;

    anon = function() {
        if ($(name + 'Loader')) {
            Effect.Fade($(name + 'Loader'));
        }

        Effect.Appear(i);
    }

    $(name + 'Container').appendChild(i);
    i.onload = anon;
    i.onafterupdate = anon; //IE only?
    i.onreadystatechange = function() {
        if (i.readyState=="complete") { anon(); }
    }

    return true;
}

// Returns the ElementID of an object.
function gbid(obj) {
    if (document.all)   return document.all[obj];
    else return document.getElementById(obj);
}

// Returns the ElementID of an object from parent frame.
function gbpid(id) {
    return window.top.document.getElementById(id)
}

// creates a popup window
function vxpopup(tgt, name, width, height, rVal) {
    // left = (half screen width) - (half width)
    // top = (half screen height) - (half height)

    if (!width)
        width = window.screen.width;

    if (!height)
        height = window.screen.height;

    var ratio = (window.screen.width / window.screen.height)

    var ran_unrounded=Math.random()*5;
    var ran_number=Math.round(ran_unrounded)*5;

    var left;
    var top;



    left = (window.screen.width / 2) - (width / 2);// + ran_number;
    top  = (window.screen.height / 2) - (height / 2);// + ran_number;

    x = window.open(tgt, "win" + name, "'toolbar=1,scrollbars=1,location=0,status=1,menubar=1,resizable=1,width=" + width + ",height=" + height + ",top=" + top + ",left=" +  left + "'");

    //x.captureEvents(Event.UNLOAD);

    if (x.focus) { x.focus(); }
    //This should work, but doesn't, to refresh parent onclose/whatever.

    //x.onsubmit=opener.location.reload;
    //x.onunload=opener.location.reload;
    //Return false to stop page load continuing, even though it's success.

    __currentwindow = x;
    if (rVal) {
        return rVal;
    }
}

function testmsg() {
    alert('HI');
}

function parentRefresh() {
    if (window.opener) {
        window.opener.location = window.opener.location;
        window.opener.focus();
    }

    if (window.top) {
        window.top.close();
    } else {
        window.close();
    }
}

// Gets the active style element
function getStyle(x, styleProp) {
    if (window.getComputedStyle)
    var y = window.getComputedStyle(x,null).getPropertyValue(styleProp);
    else if (x.currentStyle)
    var y = eval('x.currentStyle.' + styleProp);
    return y;
}

/* Position functions */
function posLeft (ob) {
    var ol = 0;

    do {
        if (navigator.appVersion.indexOf("MSIE") != -1) {
            if (getStyle(ob, 'position').indexOf('relative') != -1)
            ol -= ob.offsetLeft;
        }

        ol += ob.offsetLeft;
    } while ((ob = ob.offsetParent) != null);

    return ol;
}

function posTop (ob) {
    var ot = 0;

    do {
        ot += ob.offsetTop;
    } while ((ob = ob.offsetParent) != null);

    return ot;
}

function screenHeight() {
    if (self.innerHeight) {
        return self.innerHeight;
    } else if (document.documentElement && document.documentElement.clientHeight) {
        return document.documentElement.clientHeight;
    } else if (document.body) {
        return document.body.clientHeight;
    }
}

function screenWidth() {
    if (self.innerWidth) {
        return self.innerWidth;
    } else if (document.documentElement && document.documentElement.clientWidth) {
        return document.documentElement.clientWidth;
    } else if (document.body) {
        return document.body.clientWidth;
    }
}

function posHeight(ob) {
    return ob.offsetHeight;
}

function posWidth(ob) {
    return ob.offsetWidth;
}

/* Popup functions */
function rip(obj) {
    var ripped = obj;

    if (ripped) {
        if (ripped.style.ripped)
        return;

        var parent = obj.parentNode;
        parent.removeChild(ripped);

        var body = document.getElementsByTagName('body')[0];
        body.appendChild(ripped);

        ripped.style.ripped = true;
    }
}

function popup(div, anchor) {
    popupAt(div, posLeft(anchor), posTop(anchor), posWidth(anchor), posHeight(anchor));
}

function popup_shadow(div, anchor) {
    popupAt(div, posLeft(anchor), posTop(anchor), posWidth(anchor), posHeight(anchor), true);
}

function hidePopup(div) {
    if (div) {
        rip(div);
        div.style.display = "none";
    }
}


function notePopper(parentid, childid, callback, id) {
    if (id != childid.foo) {
        childid.foo = id;

        if (childid.style.display != "none") {
            childid.style.display = 'none';
        }
    }

    if (childid.style.display != "none") {
        Effect.BlindUp(childid);
        Effect.Fade(childid);
        callback(false);
    } else {
        Effect.BlindDown(childid);
        Effect.Appear(childid);
        callback(true);
    }

}


function togglePopup(obj, anchor) {
    if (!obj) return;

    obj.style.display = (obj.style.display == 'none') ? 'block' : 'none';

    if (obj.style.display != 'none') {
        popupAt(obj, posLeft(anchor), posTop(anchor), posWidth(anchor), posHeight(anchor));
    }
}


function popupAt(div, anchor_left, anchor_top, anchor_width, anchor_height) {
    rip(div);

    var screen_bottom = screenHeight();
    var screen_right = screenWidth();

    if (isNaN(window.screenX)) {
        screen_right += document.body.scrollLeft;
        screen_bottom += document.body.scrollTop;
    } else {
        screen_right += window.pageXOffset;
        screen_bottom += window.pageYOffset;
    }

    if (navigator.appVersion.indexOf("MSIE") == -1) {
        screen_right -= 24;
        screen_bottom -= 24;
    }

    // Put it somewhere it won't cause scroll bars
    div.style.position = "absolute";
    div.style.top = -1 * anchor_top;
    div.style.left = -1 * anchor_left;

    div.style.display = "block";

    var div_left = posWidth(div);
    var div_top = posHeight(div);

    var pos_left = 0;
    var pos_top = 0;

    if (anchor_left + div_left < screen_right || anchor_left - div_left + anchor_width < 0) {
        pos_left = anchor_left;
    } else {
        pos_left = anchor_left - div_left + anchor_width;
    }

    if (anchor_top + div_top < screen_bottom || anchor_top - div_top < 0) {
        pos_top = anchor_top + anchor_height;
    } else {
        pos_top = anchor_top - div_top;
    }

    if (navigator.appVersion.indexOf("MSIE") == -1) {
        x = getStyle(div, "margin-left");
        pos_left -= parseInt(x.substring(0, x.length - 2));

        x = getStyle(div, "margin-top");
        pos_top -= parseInt(x.substring(0, x.length - 2));
    } else {
        x = getStyle(div, "marginLeft");
        if (x.indexOf('px') != -1)
        pos_left -= parseInt(x.substring(0, x.length - 2));

        x = getStyle(div, "marginTop");
        if (x.indexOf('px') != -1)
        pos_top -= parseInt(x.substring(0, x.length - 2));
    }

    // Correct for other crap
    div.style.left = pos_left + 'px';
    div.style.top = pos_top + 'px';
}

/* Criter Functions */
function popupCritter(obj, anchor) {
    if (obj.style.stuck == undefined) { obj.style.stuck = 0; }
    popup(obj, anchor);
}

function hideCritter(obj) {
    if (obj && obj.style.stuck == 0)
    obj.style.display = 'none';
}


function toggleCritter(obj) {
    obj.style.stuck = obj.style.stuck == 1 ? 0 : 1;
    hideCritter(obj);
}

function toggleDiv(obj) {
    if (obj.style.display == 'none') {
        Effect.Appear(obj.id);
    } else {
        Effect.Fade(obj.id);
    }
}
function togglediv(obj) {
    return toggleDiv(obj);
}

function showObj(obj) {
    Effect.Appear(obj.id);
}

function showObjById(id) {
    Effect.Appear(id);
}

function hideObjById(id) {
    Effect.Fade(id);
}

function hideObj(obj) {
    Effect.Fade(obj.id);
}

function getCentreLeft(obj) {
    return (screenWidth() / 2) - (posWidth(obj) / 2);
}

function getCentreTop(obj) {
    return (screenHeight() / 2) - (posHeight(obj) / 2);
}

function dismissModal() {
    Effect.DropOut('__overlay_messagebox');
    gbid('__overlay').style.display = 'none';
}

function showBgModal() {
    gbid('__bg_overlay_messagebox').style.display = 'block';
    gbid('__bg_overlay').style.display = 'block';
}

function showMsgBox(name) {
    //Disable scroll
    document.body.style.overflow = 'hidden';

    gbid('__msgbox_overlay').style.display = 'block';
    gbid('__msgbox_overlay_messagebox_'+name).style.display = 'block';
}

function dismissBgModal() {
    gbid('__bg_overlay_messagebox').style.display = 'none';
    gbid('__bg_overlay').style.display = 'none';

}

/**
 * @see zebrafy
 */
function _leopard_spot_changer(table) {
    var body, trs;

    //This should be a regexp or exploded the collection and in_array()
    if (table.className.substr(0, 7) != 'tabular') {
        return;
    }

    body = table.tBodies[0];
    if (!body) {
        return;
    }

    trs = $A(body.getElementsByTagName("tr"));

    var even = false;
    trs.each(function(tr) {
                if (tr.parentNode.parentNode.className.substr(0,7) == 'tabular') {
                    tr.className = even ? 'even' : 'odd';
                    even = !even;
                }
            });
}

function zebrify() {
    // get all tables on the page
    var tables = $A(document.getElementsByTagName("table"));

    tables.each(_leopard_spot_changer);
}

/**
 * Return boolean for keyCode of (left, up down right, backspace, delete, enter)
 */
function is_manipulation(keyCode) {
    var enter = 13;
    var left  = 37;
    var right = 39;
    var up    = 38;
    var down  = 40;
    var tab   =  0;
    var del   = 46;
    var back  =  8;


    var match = false;
    var keystrokes = $A([enter, left, right, up, down, tab, del, back]);

    keystrokes.each(function(keystroke) {
        if (!match) {
            match = keystroke == keyCode;
        }
    });

    return match;
}
/**
 * @todo    Wish upon a star for DOM Level 3
 * @see     http://www.w3.org/TR/DOM-Level-3-Events/events.html#Events-KeyboardEvent-keyIdentifier
 */
function keydown_numeric(event) {
    var key;
    document.all ? key = event.keyCode : key = event.which;
    return ((key >= 48 && key <= 57) || is_manipulation(key));
}

function keydown_percentage(event, node) {
    var numeric = keydown_numeric(event);
    var key;
    var next_value;
    var value;
    var selected = "";

    if (!numeric) {
        return numeric;
    }
    value = node.value;

    document.all ? key = event.keyCode : key = event.which;

    if (node.selectionEnd) {

        selected = value.substring(node.selectionStart, node.selectionEnd);
        var before = value.substring(0, node.selectionStart);
        var after = value.substring(node.selectionEnd);
        value = String.concat(before, after);
    }

    next_value = parseInt(String.concat(value, String.fromCharCode(key)));

    if (next_value > 100 && !is_manipulation(key)) {
        return false;
    }

    return true;
}

function keydown_alpha(e) {
    var k;
    document.all ? k = e.keyCode : k = e.which;
    return ((k > 64 && k < 91) || (k > 96 && k < 123) || is_manipulation(k));
}

function keydown_currency(el, e) {
    var k;
    document.all ? k = e.keyCode : k = e.which;

    // if input is a number or . (or the other control keys)
    if ((k >= 48 && k <= 57)  || is_manipulation(k)) {
        // ensure there is only one .
        if (k == 46 && (el.value.indexOf('.') > 0)) {
            //ignore more than one .
            return false;
        }
        return true;
    }
    return false;
}

function isset(variable_name) {
    return variable_name != null && !(typeof(variable_name) == 'undefined');
}

function onkeyup_currency(el) {

    if (!isset(el)) {
        return;
    }

    if (!isset(el.value)) {
        return;
    }

    var bits = new Array();
    var builtstring = '';
    var startval = el.value;



    while (startval.indexOf(',') != -1) {
        startval = startval.replace(',', '');
    }

    bits = startval.split('.');

    var leadchars = 0;

    if (j = bits[0].length % 3){
        leadchars = j;
    }

    builtstring += startval.substring(0, leadchars);
    y = leadchars;
    while (y < bits[0].length) {
        builtstring += ',';
        builtstring += startval.substring(y, y + 3);
        y = y + 3;
    }

    if (bits.length > 1) {
        decimal =  bits[1].substring(0, 2);
        builtstring = builtstring + '.' + decimal;
    }

    if (builtstring.charAt(0) == ',') {
        builtstring = builtstring.substring(1, builtstring.length);
    }

    el.value = builtstring;
}

function SwapHuge(passedval, arrname) {
    var turnoff, turnon;
    for (var tmpname in eval(arrname)) {
        if (turnoff = gbid('flyout_'+tmpname)) {
            turnoff.style.display = 'none';
        }
    }

    if (turnon = gbid('flyout_' + passedval)) {
        turnon.style.display = 'block';
    }
}

function msgBox(message, buttons, title) {
    //MSG Box

}


function detectpopupblock() {
    var e = false;
    var pw1 = null;
    var pw2 = null;
    try {
        do
        {
            var d = new Date();
            var wName = "ptest_" + d.getTime();
            var testUrl = "popupTest.aspx";
            pw1 = window.open(testUrl,wName,"width=0,height=0,left=5000,top=5000",true);
            if (null == pw1 || true == pw1.closed)
            {
                e = true;
                break;
            }
            pw2 = window.open(testUrl,wName,"width=0,height=0");
            if (null == pw2 || true == pw2.closed)
            {
                e = true;
                break;
            }
            pw1.close();
            pw2.close();
            pw1 = pw2 = null;
        }
        while(false);
    }
    catch(ex) {
        e = true;
    }
    if (null != pw1) {
        try { if (!pw1.closed) pw1.close(); } catch(ex){}
    }
    if (null != pw2) {
        try { if (!pw2.closed) pw2.close(); } catch(ex){}
    }
    return e;
}

function submitJobOrder(tabObj) {
    //
    document.body.style.cursor = 'wait';
    tabObj.style.cursor = 'wait';

    var tabname = tabObj.id;
//  var tabname = tabObj.getAttribute('tabname');
    var tabfield;

    var button = gbid('__job_order_submit');

    var form = getParentForm(button);


    var elements = form.getElementsByTagName('input');
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].name == 'tab') {
            tabfield = elements[i];
        }
    }

    if (!tabfield) {
        //Add a hidden field storing this tabname
        tabfield = document.createElement('input');
        tabfield.type = 'hidden';
    }

    tabfield.name = 'tab';
    tabfield.value = tabname;

    form.appendChild(tabfield);

    //Add

//  button.parentNode.appendChild(tabfield);

//  alert(tabfield.value);
    //Submit form
    gbid('__job_order_submit').click();

}

/*
* Return a Form object of the given object
*/
function getParentForm(obj) {
    var parent = obj.parentNode;

    if (!parent)
        return null;

    if (parent.nodeName == 'FORM') {
        return parent;
    } else if (parent.nodeName == 'HTML') {
        return null;
    } else {
        return getParentForm(parent);
    }
}

function filter(value) {
    value = value.replace(/<.*?>/g, "");

    return value;
}

function activatetab(currenttab) {

    try {
        var oldtab = gbid(__currenttab);
        var olddetail = gbid(__currenttab + '_main');
        var currentdetail = gbid(currenttab.id + '_main');

        if (olddetail == currentdetail) {
            return;
        }

        currenttab.className = 'hand tab activeTab';
        currentdetail.style.visibility = 'visible';
        currentdetail.style.display = 'block';


        oldtab.className = '';
        oldtab.className = 'hand tab';
        olddetail.style.display = 'none';
        olddetail.style.visibility = 'hidden';

        __currenttab = currenttab.id;
    } catch(e) {
        alert(e);
    }
}



function addNewAppointment(obj) {
    try {
        var form = document.getElementById('addnewappointment');
        //Set Date Field
        gbid('apnt_date').value = obj.getAttribute('date');

        //Set Time Field
        gbid('apnt_time').value = obj.getAttribute('time');

        popup(form, obj);

        form.onmouseover = new Function("isOver = true");
        form.onmouseout = new Function("isOver = false;");

        document.onclick = new Function("document.onclick = new Function(\"if (isOver == false) hidePopup(gbid('addnewappointment'));\");");
        //                      form.onclick = new Function("gbid('addnewappointment').onclick = new Function(\"alert('yo');\");");
    } catch (e) {
        alert(e);
    }
}

function quickUpdateSwitcher(seed, status) {

    switch (status) {
        case '15':
            // if status is inspected, show the input for inspection date, hide anything else as required.
            gbid('appointment'+seed).style.display = 'none';
            gbid('delay'+seed).style.display = 'none';
            gbid('inspected'+seed).style.display = 'block';
            gbid('hold'+seed).style.display = 'none';
            break;

        case '7':
            // status appointment made
            gbid('inspected'+seed).style.display = 'none';
            gbid('delay'+seed).style.display = 'none';
            gbid('appointment'+seed).style.display = 'block';
            gbid('hold'+seed).style.display = 'none';
            break;


        case '8':
            // status if there is a delay set
            gbid('inspected'+seed).style.display = 'none';
            gbid('appointment'+seed).style.display = 'none';
            gbid('delay'+seed).style.display = 'block';
            gbid('hold'+seed).style.display = 'none';
            break;

        case '17':
            // hold
            gbid('inspected'+seed).style.display = 'none';
            gbid('appointment'+seed).style.display = 'none';
            gbid('delay'+seed).style.display = 'none';
            gbid('hold'+seed).style.display = 'block';
            break;

        // hide all boxes
        default:

        gbid('inspected'+seed).style.display = 'none';
            gbid('delay'+seed).style.display = 'none';
            gbid('appointment'+seed).style.display = 'none';
            gbid('hold'+seed).style.display = 'none';
            break;
    }


    return true;
}

function recolourRow(seed) {
    gbid('row' + seed).style.backgroundColor = '#ddef86';
    return true;
}


function snappyDate(obj, fmt) {
    if (obj.value == '') {
        return null;
    }
    obj.value = obj.value.replace(/\//,'-');

    d = new Date();
    d = Date.parseDate(obj.value, fmt);

    obj.value = d.print(fmt);
}

function decodeEntities(xml) {
    return xml.replace(/&amp;/gi, "&");
}


function checkIt(string) {
    place = detect.indexOf(string) + 1;
    thestring = string;
    return place;
}

function showClock(container) {
    var now = new Date();
    var hours = now.getHours();
    var minutes = now.getMinutes();
    var seconds = now.getSeconds();
    var month = now.getMonth() + 1;
    var day = now.getDate();
    var year = now.getFullYear();

    var timeValue = day + "/" + month + "/" + year;

    timeValue += " " + ((hours >12) ? hours -12 :hours);

    if (timeValue == "0")
        timeValue = 12;
    timeValue += ((minutes < 10) ? ":0" : ":") + minutes;

    timeValue += ((seconds < 10) ? ":0" : ":") + seconds;
    timeValue += (hours >= 12) ? " PM" : " AM";

    gbid(container).innerHTML = '&nbsp;' + timeValue + '&nbsp;';

    setTimeout("showClock('"+container+"')",1000);
}

function encodeHtml(string) {
    string = escape(string);
    string = string.replace(/\//g,"%2F");
    string = string.replace(/\?/g,"%3F");
    string = string.replace(/=/g,"%3D");
    string = string.replace(/&/g,"%26");
    string = string.replace(/@/g,"%40");
    return string;
}




var detect = navigator.userAgent.toLowerCase();
var OS,browser,version,total,thestring;

if (checkIt('konqueror')) {
    browser = 'Konqueror';
    OS = 'Linux';
}
else if (checkIt('safari')) { browser = 'Safari'; }
else if (checkIt('omniweb')) { browser = 'OmniWeb'; }
else if (checkIt('opera')) { browser = 'Opera'; }
else if (checkIt('webtv')) { browser = 'WebTV'; }
else if (checkIt('icab')) { browser = 'iCab'; }
else if (checkIt('msie')) { browser = 'Internet Explorer'; }
else if (!checkIt('compatible')) {
    browser = 'Netscape Navigator';
    version = detect.charAt(8);
}
else { browser = 'An unknown browser'; }

if (!version) version = detect.charAt(place + thestring.length);

if (!OS) {
    if (checkIt('linux')) OS = 'Linux';
    else if (checkIt('x11')) OS = 'Unix';
    else if (checkIt('mac')) OS = 'Mac'
    else if (checkIt('win')) OS = 'Windows'
    else OS = 'an unknown operating system';
}

function gotoNextTabindex(field) {
    var nextindex;
    var tabindexes = new Array();

    var form = getParentForm(field);

    if (form == null) {
        // Can't go to next tab in form, if there's no form
        return;
    }

    var elements = form.getElementsByTagName('input');
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].tabIndex) {
            tabindexes[elements[i].tabIndex] = elements[i].id;
        }
    }

    nextindex = field.tabIndex + 1;
    if (tabindexes[nextindex]) {
        Try.these(
            function() { $(tabindexes[nextindex]).focus(); }
        )
    }

}



var ns = (navigator.appName.indexOf("Netscape") != -1);
var d = document;
var px = document.layers ? "" : "px";

/**
 * @todo    Rework with prototype?
 */
function JSFX_FloatDiv(id, sx, sy) {
    var el=d.getElementById?d.getElementById(id):d.all?d.all[id]:d.layers[id];
    window[id + "_obj"] = el;
    if(d.layers)el.style=el;
    el.cx = el.sx = sx;el.cy = el.sy = sy;
    el.sP=function(x,y){this.style.left=x+px;this.style.top=y+px;};
    el.flt=function() {
        var pX, pY;
        pX = (this.sx >= 0) ? 0 : ns ? innerWidth :
        document.documentElement && document.documentElement.clientWidth ?
        document.documentElement.clientWidth : document.body.clientWidth;
        pY = ns ? pageYOffset : document.documentElement && document.documentElement.scrollTop ?
        document.documentElement.scrollTop : document.body.scrollTop;
        if(this.sy<0)
        pY += ns ? innerHeight : document.documentElement && document.documentElement.clientHeight ?
        document.documentElement.clientHeight : document.body.clientHeight;
        this.cx += (pX + this.sx - this.cx)/8;this.cy += (pY + this.sy - this.cy)/8;
        this.sP(this.cx, this.cy);
        setTimeout(this.id + "_obj.flt()", 40);
    }
    return el;
}


/**
 * @todo    change this to use prototype's each()
 */
function hideInputDiv(id) {
    var div = gbid(id);

    if (!div) {
        return false;
    }

    div.style.display = 'none';

    //Disable input fields
    var inputs = div.getElementsByTagName('input');

    for (var i = 0; i < inputs.length; i++) {
        inputs[i].disabled = true;
    }

    //Enable input fields
    var textareas = div.getElementsByTagName('textarea');

    for (var i = 0; i < textareas.length; i++) {
        textareas[i].disabled = true;
    }
}


/**
 * @todo    Customise for job first tab rewrite bit.
 * @todo    change this to use prototype's each()
 */
function hideInputDiv2(id) {
    var div = gbid(id);

    if (!div) {
        return false;
    }

    div.style.display = 'none';

    //Disable input fields
    var inputs = div.getElementsByTagName('input');

    for (var i = 0; i < inputs.length; i++) {
        inputs[i].disabled = true;
    }

}

/**
 * @todo    Customise for job first tab rewrite bit.
 * @todo    change this to use prototype's each()
 */
function showInputDiv2(id, overridedefault) {
    if (!overridedefault) {
        overridedefault = false;
    }

    var div = gbid(id);

    if (!div) {
        return false;
    }

    div.style.display = 'block';

    //Enable input fields
    var inputs = div.getElementsByTagName('input');

    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].getAttribute('defaultdisabled') != 'true') {
            inputs[i].disabled = false;
        }

        if (inputs[i].getAttribute('defaultdisabled') == 'true' && overridedefault == true) {
            inputs[i].disabled = false;
        }
    }

}

function showInputDiv(id, overridedefault) {
    if (!overridedefault) {
        overridedefault = false;
    }

    var div = gbid(id);

    if (!div) {
        return false;
    }

    div.style.display = 'block';

    //Enable input fields
    var inputs = div.getElementsByTagName('input');

    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].getAttribute('defaultdisabled') != 'true') {
            inputs[i].disabled = false;
        }

        if (inputs[i].getAttribute('defaultdisabled') == 'true' && overridedefault == true) {
            inputs[i].disabled = false;
        }
    }

    //Enable input fields
    var textareas = div.getElementsByTagName('textarea');

    for (var i = 0; i < textareas.length; i++) {
        textareas[i].disabled = false;
    }
}

function clearInputFields(div) {
    if (!div) {
        return false;
    }

    //Input fields
    var inputs = div.getElementsByTagName('input');

    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].type != 'submit' &&
                inputs[i].type != 'button' &&
                inputs[i].type != 'hidden' &&
                inputs[i].type != 'radio' &&
                inputs[i].type != 'checkbox')
        {
            inputs[i].value = '';
        }
    }

    //Textareas
    var textareas = div.getElementsByTagName('textarea');

    for (var i = 0; i < textareas.length; i++) {
        textareas[i].value = '';
    }

    return true;
}

/**
 * It's called form.reset?
 */
function clearAllInputFields(form) {
    if (!form) {
        return false;
    }

    //Input fields
    var inputs = form.getElementsByTagName('input');

    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].type != 'submit' &&
                inputs[i].type != 'button' &&
                inputs[i].type != 'radio' &&
                inputs[i].name != 'tab' &&
                inputs[i].name != 'job_id' &&
                inputs[i].name != 'jr_id' &&
                inputs[i].name != 'standalone'
            )
        {
            inputs[i].value = '';
        }
    }

    //Textareas
    var textareas = form.getElementsByTagName('textarea');

    for (var i = 0; i < textareas.length; i++) {
        textareas[i].value = '';
    }

    return true;
}


/**
* Show an input field and ensure it's enabled
*
* @param int id - Id of the input field
* @return none
*/
function showField(id) {
    showObjById(id);
    gbid(id).disabled = false;
}

/**
* Hide an input field and disable it
*
* @param int id - Id of the input field
* @return none
*/
function hideField(id) {
    hideObjById(id);
    gbid(id).disabled = true;
}

/**
 * Turn a container div into a 'loading' or 'spinning' graphic
 */
function setSpinning(container) {
    var containerObj = gbpid(container);
    if (containerObj) {
        containerObj.innerHTML = '<img src=\"/presentation/default/img/ui/indicator.gif\" />';
        containerObj.style.display = 'none';
        Effect.Appear(containerObj);
    }
}

/**
 * Empty a container, which will stop it from spinning
 */
function stopSpinning(container) {
    var containerObj = gbpid(container);
    if (containerObj) {
        Effect.Fade(containerObj);
    }
}


function toggleSendToComplianceButton(buttonID, checkbox) {
    var fieldObj = gbpid(buttonID);
    var checkboxObj = gbpid(checkbox);
    if (fieldObj && checkboxObj) {
        if(checkboxObj.checked) {
            fieldObj.disabled = false;
            fieldObj.className = "button";
        } else {
            fieldObj.disabled = true;
            fieldObj.className = "button disabled";
        }
    }
}

function activateSendToComplianceButton(buttonID, checkField) {
    var buttonObj = gbpid(buttonID);
    var fieldObj = gbpid(checkField);
    if (fieldObj && buttonObj) {
        if(trim(fieldObj.value) != '') {
            buttonObj.disabled = false;
            buttonObj.className = "button";
        } else {
            buttonObj.disabled = true;
            buttonObj.className = "button disabled";
        }
    }
}


function toggleFieldEnabled(fieldObj) {
    fieldObj.disabled = (fieldObj.disabled == true) ? false : true;
}

function trim(str) {
    return str.replace(/^\s*|\s*$/g,"");
}
/*
 *  Swap two html elements via a radio button control
 *
 *  @author Alex Moore
 *
 *  @param string,object $event_trigger         The id of the radio button or a reference to the radio object
 *  @param string,object $element_to_hide       The element to hide when this radio button is selected
 *  @param string,object $element_to_show       The element to show when this radio button is selected
 *
 *  @todo Fix the crossfade so it can't be interrupted
 */
function swap($event_trigger, $element_to_hide, $element_to_show) {
    /*
    $('debuga').innerHTML = 'enter:' + enter.id + '<br />address_input:' + $F('address_input') + '<br />pobox_input:' + $F('pobox_input');
    */
    $instant = true;

    if($F($event_trigger) == 'on' && $($element_to_show).style.display == 'none') {
        if($instant == true) {
            Element.hide($element_to_hide);
            Element.show($element_to_show);
        } else {
            Effect.Fade($element_to_hide,   { duration:1, from:1.0, to:0.0 });
            Effect.Appear($element_to_show, { duration:1, from:0.0, to:1.0 });
        }
    }
}

/*
I really have to stop reading /.
*/
function omgPonies(reply) {
    if (gbid('displaySimilarValuations')) {
        stopSpinning('displaySimilarValuationsIndicator');
        gbid('displaySimilarValuations').innerHTML = reply.responseText;
        Effect.BlindDown($('displaySimilarValuations'));
    } else {
        renderSuccess(reply);
    }
}


function lookupSimilarAddresses(frm) {
    setSpinning('displaySimilarValuationsIndicator');
    $('displaySimilarValuations').style.display = 'none';

    var info = Form.serialize(frm);
    var request = new Ajax.Request(
            'job-similar-address.php',
            {
                method: 'post',
                parameters: info,
                onSuccess:omgPonies,
                onFailure:renderFailure
            });

}

/*
    Synchronise job from tablet
*/
function syncFromTablet(job_id) {

    var url = 'jobsync-fromtablet.php';
    var params = 'job_id=' + job_id;

    var myAjax = new Ajax.Request(
            url,
            {
                method: 'get',
                parameters: params,
                onComplete: function(http) {
                                 window.location = window.location;
                            }
            });
}
/*
    Add to tablet
*/
function addToTablet(job_id) {

    var url = 'jobsync-totablet.php';
    var params = 'job_id=' + job_id;

    var myAjax = new Ajax.Request(
            url,
            {
                method: 'get',
                parameters: params,
                onComplete: function(http) {
                                 window.location = window.location;
                            }
            });
}
/**
 * Are we using IE7
 * AS IF WE EVEN HAVE TO DO THIS!! BAAHHHHH!
 */
function isIE7() {
    return (isIE) && (navigator.appVersion.indexOf("MSIE 7.0") > -1);
}

function _log(str) {
    Try.these(function() { console.info(str); });
}

/**
 * A one off function for updating resultset rows depending on status.
 * @todo    Shift me elsewhere.
 */
function _result_set_status(node, color, opacity) {
    Try.these(
        function() {
            var n = node.parentNode.parentNode.style;
            n.backgroundColor = color + ' !important';
            n.opacity = opacity;
        });
}

/**
 * Hide all select boxes
 */
function selects(visible) {
    var selectBoxes = $A(document.getElementsByTagName("SELECT"));

    selectBoxes.each(function(select) {
        if (visible) {
            select.style.visibility = "visible";
        } else {
            select.style.visibility = "hidden";
        }
    });
}

/**
 * Does some of the heavy lifting for the CLS_html::listBuilder()
 * @param HTMLFormElement frm  The form to which our components belong
 * @param string name          The name
 */
function appendListItem(frm, name) {

    var elements  = $A(frm.getElementsByTagName('input'));   //input elements in this form
    var listName  = name + '_list[]';                        //the name of the form array
    var hcName    = name + '_hc';                            //the hugecomplete input field name
    var item_name = '';                                      //the item name
    var item_id   = '';                                      //the item id
    var nothing_selected = false;

    elements.each(function(element) {
                        switch (element.name) {
                            case hcName:
                                if (element.value == '') {
                                    nothing_selected = true;
                                }
                                item_name = element.value;
                                element.value = '';//clear the hc field on submit
                                break;
                            case name:
                                item_id = element.value;
                                break;
                        }
                    });

    if (nothing_selected) {
        alert('No item selected.');
        return;
    }

    //Do I already exist?
    var existing = $A($(name + '_new_items').getElementsByTagName('input'));
    var found = false;
    existing.each(function (input) {
        if (input.type == 'checkbox') {
            if (input.value == item_id) {
                found = true;
            }
        }
    });

    if (found) {
        return;
    }

    //build the html
    var check = document.createElement('input');
    var label = document.createElement('label');
    var li = document.createElement('li');

    check.type = 'checkbox';
    check.checked = 'checked';
    check.value = item_id;
    check.name = listName;
    check.onchange = function() { removeListItem(li, $(name + '_new_items')); };

    label.appendChild(check);
    label.appendChild(document.createTextNode(item_name));

    li.setAttribute('class', 'list_item');
    li.appendChild(label);
    $(name + '_new_items').appendChild(li);
}


/**
 * Remove the specified li from a given ul.
 *
 * @param HTMLUnorderedListElement listItem, HTMLElement parent
 */
function removeListItem(listItem, parent) {
    parent.removeChild(listItem);
}

function toggle_clippr(obj) {
    text = obj.title;
    obj.title = obj.innerHTML;

    obj.innerHTML = text;

    new Effect.Highlight(obj);
}
