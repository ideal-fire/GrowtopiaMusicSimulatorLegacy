// happy.js, the main source for Growtopia Music Simulator The Third
////////////////////////
/// END STUPID COMMENT AND LOADING INFORMATION LINE
/// VARIABLES START
///////////////////////

// It's da canvas.
var c = document.getElementById("mainCanvas");
// Canvas' context.
var ctx = c.getContext("2d");
// Each time an image finishes loaded, this goes up by one.
var imagesReady=0;
// I'm the map, I'm the map, I'm the map, I'm the maaaaaaaaaaaaaaaaaap. I think that's how it goes.
var map = new Array(400);
// Current page you're on. Max for this variable is 15 b/c zero based. But really 16 pages.
var currentPage=0;
// Current note you're using. 
var currentNote=1;
// Contains x variable and y variable. It's the x and y position of the canvas. Mouse cords use this to be accurate.
var canvasPosition;
// True if mouse is down.
var MouseIsDown=false;
// Current playing position
var currentPlayX=0;
// True if song is playing
var playing=false;
// TThe max x.
var maxX=1;
// THe number of miliseconds between notes.
var bpmMiliseconds=150;
// The settimeout for the next note.
var nextNoteTimeout;

var minimalSettings=false;
var playOnPlace=true;

var lastX=-1;
var lastY=-1;

// Note id before right clicking
var pastNoteid;

////////////////////////
/// END VARIABLES
/// START IMAGE LOADING
///////////////////////

// Executed when an image is loaded.
// Will check if all images are done loading.
function ImageOnLoad(){
	imagesReady=imagesReady+1;
	ImageLoadCheck();
}

var backgroundImage = new Image();
backgroundImage.onload = ImageOnLoad;

var boxImage = new Image();
boxImage.onload = ImageOnLoad;
boxImage.src="./Images/Grid.bmp"

////// Notes

var drumImage = new Image();
drumImage.onload = ImageOnLoad;
drumImage.src="./Images/Drum.png";

var pianoImage = new Image();
pianoImage.onload = ImageOnLoad;
pianoImage.src="./Images/Piano.png"

var pianoFlatImage = new Image();
pianoFlatImage.onload = ImageOnLoad;
pianoFlatImage.src="./Images/PianoFlat.png"

var pianoSharpImage = new Image();
pianoSharpImage.onload = ImageOnLoad;
pianoSharpImage.src="./Images/PianoSharp.png"

var bassImage = new Image();
bassImage.onload = ImageOnLoad;
bassImage.src="./Images/Bass.png"

var bassFlatImage = new Image();
bassFlatImage.onload = ImageOnLoad;
bassFlatImage.src="./Images/BassFlat.png"

var bassSharpImage = new Image();
bassSharpImage.onload = ImageOnLoad;
bassSharpImage.src="./Images/BassSharp.png"

// Noteid 0 is empty box, 1 is piano image, 2 is flat, etc.
var noteImages = [boxImage,pianoImage,pianoSharpImage,pianoFlatImage,bassImage,bassSharpImage,bassFlatImage,drumImage];	


//////////////////////
/// END IMAGE LOADING
/// START FUNCTIONS
//////////////////////

// Does the main stuff if all images are loaded according to imagesReady variable.
function ImageLoadCheck(){
	if (imagesReady==9){
		console.log("Images done loading.")
		loadingStatus.innerHTML="Images done loading..."
		Redraw();
		AfterImagesLoaded();
	}else{
		if (imagesReady>9){
			return;
		}
		loadingStatus.innerHTML="Loading images... "+imagesReady+"/9"
	}
}

function Redraw(){
	ctx.drawImage(backgroundImage,0,0);
	for (var i=0;i<25;i++){
		for (var j=0;j<14;j++){
			if (map[i+currentPage*25][j]!=0){
				ctx.drawImage(noteImages[map[i+currentPage*25][j]],i*32,j*32)
			}
		}
	}
}

function AfterImagesLoaded(){
	c.addEventListener("mousedown", MouseDownPlace, false);
	c.addEventListener("mousemove", MouseMoveFunction, false);
	document.addEventListener("mouseup",MouseUpFunction,false);

	// Stolen from https://www.sitepoint.com/html5-javascript-mouse-wheel/
	if (c.addEventListener) {
		// IE9, Chrome, Safari, Opera
		c.addEventListener("mousewheel", MouseScrolled, false);
		// Firefox
		c.addEventListener("DOMMouseScroll", MouseScrolled, false);
	}
	// IE 6/7/8
	else c.attachEvent("onmousewheel", MouseScrolled);

	// Done loading everything.
	loadingStatus.innerHTML=""
}

// Stolen from https://www.sitepoint.com/html5-javascript-mouse-wheel/
function MouseScrolled(e){
	// cross-browser wheel delta
	var e = window.event || e; // old IE support
	var delta = Math.max(-1, Math.min(1, (e.wheelDelta || -e.detail)));
	SwitchToNextNote(delta);
}

function MouseUpFunction(e){

	if (e.which==3 && pastNoteid!=null){
		currentNote=pastNoteid;
	}

	MouseIsDown=false;
	lastX=-1;
	lastY=-1;
}


// Stolen from http://stackoverflow.com/questions/10730362/get-cookie-by-name
function getCookie(name) {
  var value = "; " + document.cookie;
  var parts = value.split("; " + name + "=");
  if (parts.length == 2) return parts.pop().split(";").shift();
}


// UI FUNCTIONS

function ChangePage(_amount){
	if (playing){
		return;
	}
	currentPage=currentPage+_amount;
	if (currentPage<0){
		currentPage=15;
	}else if (currentPage>15){
		currentPage=0;
	}
	UpdatePagePosition();
	Redraw();
}

function UpdatePagePosition(){
	pagePosition.innerHTML=("Page "+(currentPage+1)+"/16");
}

function StartPlaying(no){
	if (playing==false){
		if (no==false){
			currentPage=0;
		}else{
			currentPlayX=currentPage*25
		}
		UpdatePagePosition();
		Redraw();
		playing=true;
		PlayNextNote();
		playButton.src = "./Images/StopButton.png";
	}else{
		playing=false;
		clearTimeout(nextNoteTimeout);
		currentPlayX=0;
		Redraw();
		playButton.src = "./Images/Play.png";
	}
}

function NotYet(){
	alert("This function should never be called. Report to MyLegGuy plz.")
}

function PlayNextNote(){
	if (currentPlayX!=maxX){
		//ctx.clearRect(((currentPlayX%25-1)*32), 0, 32, c.height);
		if (minimalSettings==false){
			Redraw();
			ctx.globalAlpha = 0.5;
			ctx.fillRect((currentPlayX%25)*32,0,32,c.height);
			ctx.globalAlpha = 1;
		}
		//ctx.drawImage(pianoImage,((currentPlayX%25)*32),0);

		for (var i = 0; i < 14; i=i+1) {
			if (map[currentPlayX][i]!=0){
				PlayNote(map[currentPlayX][i],i)
			}
		}
		currentPlayX++;
		if (currentPlayX%25==0 && currentPlayX!=maxX && currentPage!=15){
			currentPage++;
			UpdatePagePosition();
			Redraw();
		}
		nextNoteTimeout=setTimeout(PlayNextNote, bpmMiliseconds);
	}else{
		currentPlayX=0;
		//playing=false;
		Redraw();
		currentPage=0;
		PlayNextNote();
		//playButton.src = "./Images/Play.png";
	}
	
}

function YellowPlay(){
	if (playing==false){
		Redraw();
		playing=true;
		PlayNextNote();
	}
}

function SwitchToNextNote(_amout){
	if (currentNote+_amout<0){
		currentNote=7;
	}else if (currentNote+_amout>7){
		currentNote=0;
	}else{
		currentNote=currentNote+_amout;
	}
	UpdateNoteButton();
	Redraw();
}

function InputBpm(){
	var _bpmInput = prompt("Enter BPM",ReverseBPMformula(bpmMiliseconds));
	if (isNaN(_bpmInput) || _bpmInput=='' || _bpmInput==null){
		alert("You didn't even type a number. Well done.");
		return;
	}
	if (_bpmInput<=0 || _bpmInput>=1000){
		alert("That's too high.");
		return;
	}else if (parseInt(_bpmInput)>200 || parseInt(_bpmInput)<20){
		alert("Yo, son.\nGrowtopia don't support dat BPM.\nIt's too high or low.\nBut you can use it here.")
	}
	bpmMiliseconds = BpmFormula(parseInt(_bpmInput));
}

function Halp(){
	noteSounds[0][0]=new Howl({src: ["./Sounds/piano_high_b.wav"]});
	noteSounds[0][0].play();
	Redraw();
	//alert(currentPage+";")
}

// UI FUNCTIONS END

function UpdateNoteButton(){
	noteButton.src=noteImages[currentNote].src
}

function PlayNote(noteId, noteY){
	noteSounds[noteId-1][noteY].play();
}

function BpmFormula(re){
	return 60000 / (4 * re);
}

function ReverseBPMformula(re){
	return 15000/re;
}

// Returns number as a string with three digits
function ForceThreeDigits(_num){
	if (_num<100){
		return ("0"+_num);
	}else{
		return _num;
	}
}

function MouseDownPlace(e){
	canvasPosition = GetPosition(c);
	if (e.clientY-canvasPosition.y<448 && e.clientX-canvasPosition.x<809){
		if (e.which==3){
			pastNoteid=currentNote;
			currentNote=0;
		}

		MouseIsDown=true;
		Place(e);
	}
}

function MouseMoveFunction(e){
	if (MouseIsDown && e.clientX-canvasPosition.x<800){
		canvasPosition = GetPosition(c);
		Place(e);
	}
}

function Place(e){
	if (MouseIsDown){
		if (Math.floor((e.clientX-canvasPosition.x)/32)==lastX && Math.floor((e.clientY-canvasPosition.y)/32)==lastY){
			return;
		}
		lastX=Math.floor((e.clientX-canvasPosition.x)/32);
		lastY=Math.floor((e.clientY-canvasPosition.y)/32);
		map[lastX+currentPage*25][lastY]=currentNote;
		if (playOnPlace && currentNote!=0){
			noteSounds[currentNote-1][lastY].play();
		}
		if (currentNote==0){
			if (minimalSettings==true){
				ctx.drawImage(noteImages[currentNote],lastX*32,lastY*32)
			}else{
				Redraw();
			}
		}else{
			ctx.drawImage(noteImages[currentNote],lastX*32,lastY*32)
		}
		if ((lastX+currentPage*25+1>maxX)){
			maxX=lastX+currentPage*25+1;
		}else if (lastX+currentPage*25+1<=maxX){
			detectMaxX();
		}
	}
}

// Stolen from https://www.kirupa.com/html5/getting_mouse_click_position.htm
function GetPosition(el) {
  var xPosition = 0;
  var yPosition = 0;
 
  while (el) {
    if (el.tagName == "BODY") {
      var xScrollPos = el.scrollLeft || document.documentElement.scrollLeft;
      var yScrollPos = el.scrollTop || document.documentElement.scrollTop;
 
      xPosition += (el.offsetLeft - xScrollPos + el.clientLeft);
      yPosition += (el.offsetTop - yScrollPos + el.clientTop);
    } else {
      xPosition += (el.offsetLeft - el.scrollLeft + el.clientLeft);
      yPosition += (el.offsetTop - el.scrollTop + el.clientTop);
    }
 
    el = el.offsetParent;
  }
  return {
    x: xPosition,
    y: yPosition
  };
}

function detectMaxX(){
	for (var i=0;i<400;i++){
		for (var j=0;j<14;j++){
			if (map[i][j]!=0){
				maxX=i+1;
			}
		}
	}
}

// Stolen from http://stackoverflow.com/questions/7717851/save-file-javascript-with-file-name
function saveAs(uri, filename) {
    var link = document.createElement('a');
    if (typeof link.download === 'string') {
        document.body.appendChild(link); // Firefox requires the link to be in the body
        link.download = filename;
        link.href = uri;
        link.click();
        document.body.removeChild(link); // remove the link when done
    } else {
        location.replace(uri);
    }
}

function SaveAndDownload(){
	var saveString="GMSO";
	// Save format version
	saveString+="1";
	saveString+=ForceThreeDigits(ReverseBPMformula(bpmMiliseconds));
	for (var i=0;i<400;i++){
		for (var j=0;j<14;j++){
			saveString+=map[i][j]
		}
	}

	var _filename = document.getElementById("saveTextbox").value;
	if (_filename==""){
		_filename="NoobDidntEnterFilename.AngryLegGuy"
	}

	saveAs("data:text,"+saveString,_filename)
}

function parseBool(_boolString){
	if (_boolString.toLowerCase()=="true"){
		return true;
	}else{
		return false;
	}
}

function CountSelected(){
	var counted=0;
	var noteNam="";
	for (var i=0;i<400;i++){
		for (var j=0;j<14;j++){
			if (map[i][j]==currentNote){
				counted=counted+1;
			}
		}
	}
	switch(currentNote){
		case 0:
			noteNam = "empty space";
			break;
		case 1:
			noteNam = "piano";
			break;
		case 2:
			noteNam = "piano sharp";
			break;
		case 3:
			noteNam = "piano flat";
			break;
		case 4:
			noteNam = "bass";
			break;
		case 5:
			noteNam = "bass sharp";
			break;
		case 6:
			noteNam = "bass flat";
			break;
		case 7:
			noteNam = "drum";
			break;
	}
	alert("There are "+counted+" "+noteNam+" notes.");
}

/////////////////////
/// END FUNCTIONS
/// START EVERYTHING ELSE
/////////////////////

// Create map's jagged array.
for (var i = 0; i < 400; i++) {
  map[i] = new Array(14);
}

loadingStatus.innerHTML="Setting array defaults..."
for (var i = 0; i < 400; i++) {
	for (var j = 0; j < 14; j++) {
		map[i][j]=0;
	}
}

ctx.fillStyle = "grey";

loadingStatus.innerHTML="Loading images... 0/9"

var _pop = getCookie("playOnPlace");
// We can assume the other cookie is null too because you can't set only one in the options menu.
if (_pop!=null){
	var _min = getCookie("min");
	minimalSettings = parseBool(_min);
	playOnPlace = parseBool(_pop);
	var _bgTheme = getCookie("themeBg");
	if (_bgTheme!="" && _bgTheme!=null){
		backgroundImage.src = _bgTheme;
		pop=1;
	}
}

if (_bgTheme==null || _bgTheme==""){
	if (document.all && !document.addEventListener) {
  		alert('lol noob uze ie 8 or olderlolololol');
  		backgroundImage.src="./Images/Background.png";
	}else{
		backgroundImage.src="data:image/png;base64,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"
	}
	imagesReady++;
	ImageLoadCheck();
}