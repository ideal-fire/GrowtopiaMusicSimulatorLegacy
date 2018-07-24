function makeSound(_name){
	return new Howl({src: [_name+".wav",_name+".mp3"]});
}


// This is an array of all the piano note sounds.
// Entrys in the array correspond to the y value of a note.
var pianoSounds = [
makeSound("./Sounds/piano_high_b"),
makeSound("./Sounds/piano_high_a"),	
makeSound("./Sounds/piano_high_g"),
makeSound("./Sounds/piano_high_f"),
makeSound("./Sounds/piano_high_e"),	
makeSound("./Sounds/piano_high_d"),
makeSound("./Sounds/piano_c"),
makeSound("./Sounds/piano_b"),
makeSound("./Sounds/piano_a"),	
makeSound("./Sounds/piano_g"),
makeSound("./Sounds/piano_f"),
makeSound("./Sounds/piano_e"),
makeSound("./Sounds/piano_low_d"),
makeSound("./Sounds/piano_low_c")
]


var pianoFlatSounds = []

var pianoSharpSounds = []

var bassSounds = []

var bassFlatSounds = []

var bassSharpSounds = []

var drumSounds = []


pianoSharpSounds[0] = makeSound("./Sounds/piano_high_c");
pianoSharpSounds[1] = makeSound("./Sounds/piano_high_a_sharp");
pianoSharpSounds[2] = makeSound("./Sounds/piano_high_g_sharp_a_flat");
pianoSharpSounds[3] = makeSound("./Sounds/piano_high_f_sharp");
pianoSharpSounds[4] = makeSound("./Sounds/piano_high_f");
pianoSharpSounds[5] = makeSound("./Sounds/piano_d_sharp_e_flat");
pianoSharpSounds[6] = makeSound("./Sounds/piano_c_sharp_d_flat");
pianoSharpSounds[7] = makeSound("./Sounds/piano_c");
pianoSharpSounds[8] = makeSound("./Sounds/piano_a_sharp_b_flat");
pianoSharpSounds[9] = makeSound("./Sounds/piano_g_sharp_a_flat");
pianoSharpSounds[10] = makeSound("./Sounds/piano_f_sharp_g_flat");
pianoSharpSounds[11] = makeSound("./Sounds/piano_f");
pianoSharpSounds[12] = makeSound("./Sounds/piano_low_d_sharp_e_flat");
pianoSharpSounds[13] = makeSound("./Sounds/piano_low_c_sharp_or_d_flat");

pianoFlatSounds[0] = makeSound("./Sounds/piano_high_a_sharp");
pianoFlatSounds[1] = makeSound("./Sounds/piano_high_g_sharp_a_flat");
pianoFlatSounds[2] = makeSound("./Sounds/piano_high_f_sharp_g_flat");
pianoFlatSounds[3] = makeSound("./Sounds/piano_high_e");
pianoFlatSounds[4] = makeSound("./Sounds/piano_d_sharp_e_flat");
pianoFlatSounds[5] = makeSound("./Sounds/piano_c_sharp_d_flat");
pianoFlatSounds[6] = makeSound("./Sounds/piano_b");
pianoFlatSounds[7] = makeSound("./Sounds/piano_a_sharp_b_flat");
pianoFlatSounds[8] = makeSound("./Sounds/piano_g_sharp_a_flat");
pianoFlatSounds[9] = makeSound("./Sounds/piano_f_sharp_g_flat");
pianoFlatSounds[10] = makeSound("./Sounds/piano_e");
pianoFlatSounds[11] = makeSound("./Sounds/piano_low_d_sharp_e_flat");
pianoFlatSounds[12] = makeSound("./Sounds/piano_low_c_sharp_or_d_flat");
pianoFlatSounds[13] = makeSound("./Sounds/piano_c_flat_which_is_b");

drumSounds[0] = makeSound("./Sounds/drum_0");
drumSounds[1] = makeSound("./Sounds/drum_1");
drumSounds[2] = makeSound("./Sounds/drum_2");
drumSounds[3] = makeSound("./Sounds/drum_3");
drumSounds[4] = makeSound("./Sounds/drum_4");
drumSounds[5] = makeSound("./Sounds/drum_5");
drumSounds[6] = makeSound("./Sounds/drum_6");
drumSounds[7] = makeSound("./Sounds/drum_0");
drumSounds[8] = makeSound("./Sounds/drum_1");
drumSounds[9] = makeSound("./Sounds/drum_2");
drumSounds[10] = makeSound("./Sounds/drum_3");
drumSounds[11] = makeSound("./Sounds/drum_4");
drumSounds[12] = makeSound("./Sounds/drum_5");
drumSounds[13] = makeSound("./Sounds/drum_6");

bassSounds[0] = makeSound("./Sounds/bass_high_b");
bassSounds[1] = makeSound("./Sounds/bass_a");
bassSounds[2] = makeSound("./Sounds/bass_g");
bassSounds[3] = makeSound("./Sounds/bass_f");
bassSounds[4] = makeSound("./Sounds/bass_e");
bassSounds[5] = makeSound("./Sounds/bass_d");
bassSounds[6] = makeSound("./Sounds/bass_c");
bassSounds[7] = makeSound("./Sounds/bass_b");
bassSounds[8] = makeSound("./Sounds/bass_low_a");
bassSounds[9] = makeSound("./Sounds/bass_low_g");
bassSounds[10] = makeSound("./Sounds/bass_low_f");
bassSounds[11] = makeSound("./Sounds/bass_low_e");
bassSounds[12] = makeSound("./Sounds/bass_low_d");
bassSounds[13] = makeSound("./Sounds/bass_low_c");

bassSharpSounds[0] = makeSound("./Sounds/bass_high_c");
bassSharpSounds[1] = makeSound("./Sounds/bass_b_flat_a_sharp");
bassSharpSounds[2] = makeSound("./Sounds/bass_a_flat_g_sharp");
bassSharpSounds[3] = makeSound("./Sounds/bass_g_flat_f_sharp");
bassSharpSounds[4] = makeSound("./Sounds/bass_f");
bassSharpSounds[5] = makeSound("./Sounds/bass_e_flat_d_sharp");
bassSharpSounds[6] = makeSound("./Sounds/bass_d_flat_c_sharp");
bassSharpSounds[7] = makeSound("./Sounds/bass_c");
bassSharpSounds[8] = makeSound("./Sounds/bass_low_b_flat_a_sharp");
bassSharpSounds[9] = makeSound("./Sounds/bass_low_a_flat_g_sharp");
bassSharpSounds[10] = makeSound("./Sounds/bass_low_g_flat_f_sharp");
bassSharpSounds[11] = makeSound("./Sounds/bass_low_f");
bassSharpSounds[12] = makeSound("./Sounds/bass_low_e_flat_d_sharp");
bassSharpSounds[13] = makeSound("./Sounds/bass_low_d_flat_c_sharp");

bassFlatSounds[0] = makeSound("./Sounds/bass_b_flat_a_sharp");
bassFlatSounds[1] = makeSound("./Sounds/bass_a_flat_g_sharp");
bassFlatSounds[2] = makeSound("./Sounds/bass_g_flat_f_sharp");
bassFlatSounds[3] = makeSound("./Sounds/bass_e");
bassFlatSounds[4] = makeSound("./Sounds/bass_e_flat_d_sharp");
bassFlatSounds[5] = makeSound("./Sounds/bass_d_flat_c_sharp");
bassFlatSounds[6] = makeSound("./Sounds/bass_b");
bassFlatSounds[7] = makeSound("./Sounds/bass_low_b_flat_a_sharp");
bassFlatSounds[8] = makeSound("./Sounds/bass_low_a_flat_g_sharp");
bassFlatSounds[9] = makeSound("./Sounds/bass_low_g_flat_f_sharp");
bassFlatSounds[10] = makeSound("./Sounds/bass_low_e");
bassFlatSounds[11] = makeSound("./Sounds/bass_low_e_flat_d_sharp");
bassFlatSounds[12] = makeSound("./Sounds/bass_low_d_flat_c_sharp");
bassFlatSounds[13] = makeSound("./Sounds/bass_low_b");

// SOunds correspond to noteid-1
var noteSounds = [pianoSounds,pianoSharpSounds,pianoFlatSounds,bassSounds,bassSharpSounds,bassFlatSounds,drumSounds];

//////////////////////////////////////////////////////////

/*

var imgData;
var dataSpot;

function WriteToImgdata(_val){
	imgData.data[dataSpot]=_val;
	dataSpot++;
	if (dataSpot%4==0 && dataSpot!=0){
		// Rgb isn't saved if there's zero alpha
		imgData.data[dataSpot]=255;
		dataSpot++;
	}
}

function MakeSongImage(){
	// Create the canvas
	var canvas = document.getElementById("saveCanvas");
	var ctx = canvas.getContext("2d");

	imgData = ctx.getImageData(0, 0, canvas.width, canvas.height);
	dataSpot=0;

	// Reads GMS in ANSCII
	WriteToImgdata(71);
	WriteToImgdata(77);
	WriteToImgdata(83);

	var _bpm = ReverseBPMformula(bpmMiliseconds);

	WriteToImgdata(Math.floor(_bpm/2));
	WriteToImgdata(Math.floor(_bpm/2));
	WriteToImgdata(_bpm % 3);

	console.log(dataSpot)

	for (var i=0;i<400;i++){
		for (var j=0;j<14;j++){
			WriteToImgdata(map[i][j]);
		}
	}

	

    // It's an odd number. 5600/3 r -2 
    WriteToImgdata(255);
    //WriteToImgdata(255);

    console.log(dataSpot)

    if (dataSpot!=imgData.data.length){
    	alert(dataSpot+";"+imgData.data.length)
    }

    ctx.putImageData(imgData, 0, 0);

}

*/

loadingStatus.innerHTML="Loading other in sounds folder.."
// nothing here.