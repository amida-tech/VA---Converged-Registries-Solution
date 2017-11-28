function CheckAlpha(event) {
    if (event != null) {
        var code = event.which || event.keyCode;
        if (code != null) {
            //spacebar and dash, comma, period and numbers and A-Z and a-z
            if (code == 32 || (code >= 44 && code <= 46) || (code >= 48 && code <= 57) || (code >= 65 && code <= 90) || (code >= 97 && code <= 122))
                return true;
            else
                return false;
        }
    }

    return true;
}

function CheckNumeric(event)
{
    if (event != null)
    {
        var code = event.which || event.keyCode;
        if (code != null) {
            //0-9
            if (code >= 48 && code <= 57)
                return true;
            else
                return false;
        }
    }

    return true;
}

function CheckDate(event) {
    if (event != null) {
        var code = event.which || event.keyCode;
        if (code != null) {
            //0-9 and /
            if (code >= 47 && code <= 57)
                return true;
            else
                return false;
        }
    }

    return true;
}