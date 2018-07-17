-----------------------------------------------------------------------------------------
--
-- main.lua
--
-----------------------------------------------------------------------------------------

-- Your code here

--15 across

-- 28 pages and 8 blocks wide on 29th page.



if ( system.getInfo("platformName") == "Android" ) then
   local androidVersion = string.sub( system.getInfo( "platformVersion" ), 1, 3)
   if( androidVersion and tonumber(androidVersion) >= 4.4 ) then
     native.setProperty( "androidSystemUiVisibility", "immersiveSticky" )
     --native.setProperty( "androidSystemUiVisibility", "lowProfile" )
   elseif( androidVersion ) then
     native.setProperty( "androidSystemUiVisibility", "lowProfile" )
   end
end

copying=false
print (display.contentWidth)
print (display.contentHeight)
version=19
toimport=""
savename="mysong"
mytext={}
ego = require "ego"
saveFile = ego.saveFile
loadFile = ego.loadFile
local headers = {}
savestring=""
loadstring=""
indexstring=""
saves={}
currentnote=1
playing=false
pianonotes={}
datimer=1
pianosharp={}
pianoflat={}
drum={}
bass={}
bassflat={}
basssharp={}
 group = display.newGroup()
note=1
page=1
pianonotes[1]=audio.loadSound( "piano_high_b.wav")
pianonotes[2]=audio.loadSound( "piano_high_a.wav")	
pianonotes[3]=audio.loadSound( "piano_high_g.wav")
pianonotes[4]=audio.loadSound( "piano_high_f.wav")
pianonotes[5]=audio.loadSound( "piano_high_e.wav")	
pianonotes[6]=audio.loadSound( "piano_high_d.wav")
pianonotes[7]=audio.loadSound( "piano_c.wav")
pianonotes[8]=audio.loadSound( "piano_b.wav")
pianonotes[9]=audio.loadSound( "piano_a.wav")	
pianonotes[10]=audio.loadSound( "piano_g.wav")
pianonotes[11]=audio.loadSound("piano_f.wav")
pianonotes[12]=audio.loadSound("piano_e.wav")
pianonotes[13]=audio.loadSound("piano_low_d.wav")	
pianonotes[14]=audio.loadSound("piano_low_c.wav")	
pianosharp[1]=audio.loadSound("piano_high_c.wav")
pianosharp[2]=audio.loadSound("piano_high_a_sharp.wav")	
pianosharp[3]=audio.loadSound("piano_high_g_sharp_a_flat.wav")	
pianosharp[4]=audio.loadSound("piano_high_f_sharp.wav")
pianosharp[5]=audio.loadSound("piano_high_f.wav")	
pianosharp[6]=audio.loadSound("piano_d_sharp_e_flat.wav")	
pianosharp[7]=audio.loadSound("piano_c_sharp_d_flat.wav")	
pianosharp[8]=audio.loadSound("piano_c.wav")	
pianosharp[9]=audio.loadSound("piano_a_sharp_b_flat.wav")	
pianosharp[10]=audio.loadSound("piano_g_sharp_a_flat.wav")	
pianosharp[11]=audio.loadSound("piano_f_sharp_g_flat.wav")	
pianosharp[12]=audio.loadSound("piano_f.wav")	
pianosharp[13]=audio.loadSound("piano_low_d_sharp_e_flat.wav")	
pianosharp[14]=audio.loadSound("piano_low_c_sharp_or_d_flat.wav")	
pianoflat[1]=audio.loadSound("piano_high_a_sharp.wav")
pianoflat[2]=audio.loadSound("piano_high_g_sharp_a_flat.wav")	
pianoflat[3]=audio.loadSound("piano_high_f_sharp_g_flat.wav")	
pianoflat[4]=audio.loadSound("piano_high_e.wav")	
pianoflat[5]=audio.loadSound("piano_d_sharp_e_flat.wav")	
pianoflat[6]=audio.loadSound("piano_c_sharp_d_flat.wav")	
pianoflat[7]=audio.loadSound("piano_b.wav")	
pianoflat[8]=audio.loadSound("piano_a_sharp_b_flat.wav")	
pianoflat[9]=audio.loadSound("piano_g_sharp_a_flat.wav")	
pianoflat[10]=audio.loadSound("piano_f_sharp_g_flat.wav")	
pianoflat[11]=audio.loadSound("piano_e.wav")	
pianoflat[12]=audio.loadSound("piano_low_d_sharp_e_flat.wav")	
pianoflat[13]=audio.loadSound("piano_low_c_sharp_or_d_flat.wav")	
pianoflat[14]=audio.loadSound("piano_c_flat_which_is_b.wav")
bass[1]=audio.loadSound( "bass_high_b.wav");
bass[2]=audio.loadSound( "bass_a.wav");	
bass[3]=audio.loadSound( "bass_g.wav");
bass[4]=audio.loadSound( "bass_f.wav");
bass[5]=audio.loadSound( "bass_e.wav");	
bass[6]=audio.loadSound( "bass_d.wav");
bass[7]=audio.loadSound( "bass_c.wav");	
bass[8]=audio.loadSound( "bass_low_b.wav");
bass[9]=audio.loadSound( "bass_low_a.wav");	
bass[10]=audio.loadSound( "bass_low_g.wav");	
bass[11]=audio.loadSound( "bass_low_f.wav");
bass[12]=audio.loadSound( "bass_low_e.wav");
bass[13]=audio.loadSound( "bass_low_d.wav");	
bass[14]=audio.loadSound( "bass_low_c.wav");
basssharp[1]=audio.loadSound( "bass_high_c.wav");
basssharp[2]=audio.loadSound( "bass_b_flat_a_sharp.wav");	
basssharp[3]=audio.loadSound( "bass_a_flat_g_sharp.wav");	
basssharp[4]=audio.loadSound( "bass_g_flat_f_sharp.wav");	
basssharp[5]=audio.loadSound( "bass_f.wav");
basssharp[6]=audio.loadSound( "bass_e_flat_d_sharp.wav");	
basssharp[7]=audio.loadSound( "bass_d_flat_c_sharp.wav");	
basssharp[8]=audio.loadSound( "bass_c.wav");
basssharp[9]=audio.loadSound( "bass_low_b_flat_a_sharp.wav");	
basssharp[10]=audio.loadSound( "bass_low_a_flat_g_sharp.wav");	
basssharp[11]=audio.loadSound( "bass_low_g_flat_f_sharp.wav");	
basssharp[12]=audio.loadSound( "bass_low_f.wav");
basssharp[13]=audio.loadSound( "bass_low_e_flat_d_sharp.wav");	
basssharp[14]=audio.loadSound( "bass_low_d_flat_c_sharp.wav");
bassflat[1]=audio.loadSound( "bass_b_flat_a_sharp.wav");
bassflat[2]=audio.loadSound( "bass_a_flat_g_sharp.wav");	
bassflat[3]=audio.loadSound( "bass_g_flat_f_sharp.wav");	
bassflat[4]=audio.loadSound( "bass_e.wav");	
bassflat[5]=audio.loadSound( "bass_e_flat_d_sharp.wav");	
bassflat[6]=audio.loadSound( "bass_d_flat_c_sharp.wav");	
bassflat[7]=audio.loadSound( "bass_b.wav");	
bassflat[8]=audio.loadSound( "bass_b_flat_a_sharp.wav");	
bassflat[9]=audio.loadSound( "bass_low_a_flat_g_sharp.wav");	
bassflat[10]=audio.loadSound( "bass_low_g_flat_f_sharp.wav");	
bassflat[11]=audio.loadSound( "bass_low_e.wav");	
bassflat[12]=audio.loadSound( "bass_low_e_flat_d_sharp.wav");	
bassflat[13]=audio.loadSound( "bass_low_d_flat_c_sharp.wav");	
bassflat[14]=audio.loadSound( "bass_low_b.wav");
drum[1]=audio.loadSound("drum_0.wav");
drum[2]=audio.loadSound("drum_6.wav");	
drum[3]=audio.loadSound("drum_2.wav");	
drum[4]=audio.loadSound("drum_3.wav");	
drum[5]=audio.loadSound("drum_4.wav");	
drum[6]=audio.loadSound("drum_5.wav");	
drum[7]=audio.loadSound("drum_6.wav");	
drum[8]=audio.loadSound("drum_0.wav");	
drum[9]=audio.loadSound("drum_1.wav");	
drum[10]=audio.loadSound("drum_2.wav");	
drum[11]=audio.loadSound("drum_3.wav");	
drum[12]=audio.loadSound("drum_4.wav");	
drum[13]=audio.loadSound("drum_5.wav");	
drum[14]=audio.loadSound("drum_6.wav");	

offsetx=0

donespots={{},{},{},{},{},{},{},{},{},{},{},{},{},{}}

mapobjs={{},{},{},{},{},{},{},{},{},{},{},{},{},{}}

map={
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
}


local function networkListener( event )
    if ( event.isError ) then
        print( "Network error!" )
native.showAlert( "Sad face.", "There was an error.\nMake sure you're connected to the internet and try again later.\nIf the problem persists, the importing website may be down. Contact MyLegGuy." )
    else
        
print ( "RESPONSE: " .. event.response )
    end
end






local function tapnumberofnotes( event )
   if event.action == "clicked" then
	
	thingietell=thingietell+1

if thingietell==2 then
native.showAlert( ("Info! " .. thingietell .. "/7"), ("There are " .. tostring(tpianosharp) .. " sharp piano notes."), {"Next"}, tapnumberofnotes )
elseif thingietell==3 then
native.showAlert( ("Info! " .. thingietell .. "/7"), ("There are " .. tostring(tpianoflat) .. " flat piano notes."), {"Next"}, tapnumberofnotes )
elseif thingietell==4 then
native.showAlert( ("Info! " .. thingietell .. "/7"), ("There are " .. tostring(tbass) .. " bass notes."), {"Next"}, tapnumberofnotes )
elseif thingietell==5 then
native.showAlert( ("Info! " .. thingietell .. "/7"), ("There are " .. tostring(tbassflat) .. " flat bass notes."), {"Next"}, tapnumberofnotes )
elseif thingietell==6 then
native.showAlert( ("Info! " .. thingietell .. "/7"), ("There are " .. tostring(tbasssharp) .. " sharp bass notes."), {"Next"}, tapnumberofnotes )
elseif thingietell==7 then
native.showAlert( ("Info! " .. thingietell .. "/7"), ("There are " .. tostring(tdrum) .. " drum notes."), {"Next"}, tapnumberofnotes )
elseif thingietell==8 then
tpiano=nil
tpianoflat=nil
tpianosharp=nil
tbass=nil
tbassflat=nil
tbasssharp=nil
tdrum=nil
thingietell=nil
end


    end
end



function countnotesf(event)
tpiano=0
tpianoflat=0
tpianosharp=0
tbass=0
tbassflat=0
tbasssharp=0
tdrum=0

i=1

for ty=1, 14 do
for tx=1, 25 do
if map[ty][tx]==1 then
tpiano=(tpiano+1)
elseif map[ty][tx]==2 then
tpianosharp=(tpianosharp+1)
elseif map[ty][tx]==3 then
tpianoflat=(tpianoflat+1)
elseif map[ty][tx]==4 then
tbass=(tbass+1)
elseif map[ty][tx]==5 then
tbasssharp=(tbasssharp+1)
elseif map[ty][tx]==6 then
tbassflat=(tbassflat+1)
elseif map[ty][tx]==7 then
tdrum=(tdrum+1)
end
end
end

thingietell=1


native.showAlert( ("Info! " .. thingietell .. "/7"), ("There are " .. tostring(tpiano) .. " piano notes."), {"Next"}, tapnumberofnotes )



end


function movescreen(d)

if d==1 then
if group.y==-128 then
return
end
group.y=group.y-32
notesdisplay.y=notesdisplay.y-32
elseif d==2 then
if group.y==32 then
return
end
group.y=group.y+32
notesdisplay.y=notesdisplay.y+32
elseif d==3 then
group.x=group.x-32
elseif d==4 then
group.x=group.x+32
end
end

function removenote(event)
if ( event.phase == "began" or event.phase == "moved" ) then
if donespots[event.target.arrayy][event.target.arrayx]==1 then
return;
end
if (event.target.y+group.y)-32<0 then
return;
end
donespots[event.target.arrayy][event.target.arrayx]=1
mapobjs[event.target.arrayy][event.target.arrayx]=display.newImage( "blank.png" )
mapobjs[event.target.arrayy][event.target.arrayx].x=(event.target.arrayx*32)-16
mapobjs[event.target.arrayy][event.target.arrayx].y=((event.target.arrayy-1)*32)+15
mapobjs[event.target.arrayy][event.target.arrayx].arrayx=event.target.arrayx
mapobjs[event.target.arrayy][event.target.arrayx].arrayy=event.target.arrayy
mapobjs[event.target.arrayy][event.target.arrayx]:addEventListener( "touch", addnote )
map[event.target.arrayy][event.target.arrayx+offsetx]=0
group:insert( mapobjs[event.target.arrayy][event.target.arrayx] )
group:remove( event.target )
event.target:removeSelf()
event.target=nil
end
end

function addcopy(dathing)

end

function addnote(event)
if ( event.phase == "began" or event.phase == "moved" ) then
print (event.target.y)
print (group.y)

if (event.target.y+group.y)-32<15 then
return;
end

if donespots[event.target.arrayy][event.target.arrayx]==1 then
return;
end

if copying==true then
addcopy(event.target)
end

if note==1 then
mapobjs[event.target.arrayy][event.target.arrayx]=display.newImage( "PianoNote.png" )
map[event.target.arrayy][event.target.arrayx+offsetx]=1
audio.play(pianonotes[event.target.arrayy])
elseif note==2 then
mapobjs[event.target.arrayy][event.target.arrayx]=display.newImage( "PianoSharp.png" )
map[event.target.arrayy][event.target.arrayx+offsetx]=2
audio.play(pianosharp[event.target.arrayy])
elseif note==3 then
mapobjs[event.target.arrayy][event.target.arrayx]=display.newImage( "PianoFlat.png" )
map[event.target.arrayy][event.target.arrayx+offsetx]=3
audio.play(pianoflat[event.target.arrayy])
elseif note==4 then
mapobjs[event.target.arrayy][event.target.arrayx]=display.newImage( "Bass.png" )
map[event.target.arrayy][event.target.arrayx+offsetx]=4
audio.play(bass[event.target.arrayy])
elseif note==5 then
mapobjs[event.target.arrayy][event.target.arrayx]=display.newImage( "SharpBass.png" )
map[event.target.arrayy][event.target.arrayx+offsetx]=5
audio.play(basssharp[event.target.arrayy])
elseif note==6 then
map[event.target.arrayy][event.target.arrayx+offsetx]=6
mapobjs[event.target.arrayy][event.target.arrayx]=display.newImage( "FlatBass.png" )
audio.play(bassflat[event.target.arrayy])
elseif note==7 then
map[event.target.arrayy][event.target.arrayx+offsetx]=7
mapobjs[event.target.arrayy][event.target.arrayx]=display.newImage( "Drum.png" )
audio.play(drum[event.target.arrayy])
elseif note==8 then
map[event.target.arrayy][event.target.arrayx+offsetx]=8
mapobjs[event.target.arrayy][event.target.arrayx]=display.newImage( "PianoBlank.png" )
end

donespots[event.target.arrayy][event.target.arrayx]=1

mapobjs[event.target.arrayy][event.target.arrayx].x=(event.target.arrayx*32)-16
mapobjs[event.target.arrayy][event.target.arrayx].y=((event.target.arrayy-1)*32)+15
mapobjs[event.target.arrayy][event.target.arrayx].arrayx=event.target.arrayx
mapobjs[event.target.arrayy][event.target.arrayx].arrayy=event.target.arrayy
mapobjs[event.target.arrayy][event.target.arrayx]:addEventListener( "touch", removenote )
group:insert( mapobjs[event.target.arrayy][event.target.arrayx] )
group:remove( event.target )
event.target:removeSelf()
event.target=nil
end
end


function nextpagef(event)

if playing==true then
return
end

if ( event.phase == "ended" ) then

print "Nextpage"
page=page+1
offsetx=offsetx+14
if page==29 then
page=28
offsetx=offsetx-14
end
pagetext.text=("Page: " .. page)
refreshpage()
end
end

function backpagef(event)
if playing==true then
return
end
if ( event.phase == "ended" ) then
print "Back page"
page=page-1
offsetx=offsetx-14
if page==0 then
page=1
offsetx=offsetx+14
end
pagetext.text=("Page: " .. page)
refreshpage()
end
end


function refreshpage()

--14
--9

if pagetext~=nil then
pagetext.text=("Page: " .. page)
end

group:removeSelf()
group=nil
group=display.newGroup( )

for i2=1, 14 do
for i=1, 14 do

if map[i2][i+offsetx]==0 then
mapobjs[i2][i]=display.newImage("blank.png")
mapobjs[i2][i]:addEventListener( "touch", addnote )
elseif map[i2][i+offsetx]==1 then
mapobjs[i2][i]=display.newImage( "PianoNote.png" )
elseif map[i2][i+offsetx]==2 then
mapobjs[i2][i]=display.newImage( "PianoSharp.png" )
elseif map[i2][i+offsetx]==3 then
mapobjs[i2][i]=display.newImage( "PianoFlat.png" )
elseif map[i2][i+offsetx]==4 then
mapobjs[i2][i]=display.newImage( "Bass.png" )
elseif map[i2][i+offsetx]==5 then
mapobjs[i2][i]=display.newImage( "SharpBass.png" )
elseif map[i2][i+offsetx]==6 then
mapobjs[i2][i]=display.newImage( "FlatBass.png" )
elseif map[i2][i+offsetx]==7 then
mapobjs[i2][i]=display.newImage( "Drum.png" )
elseif map[i2][i+offsetx]==8 then
mapobjs[i2][i]=display.newImage( "PianoBlank.png" )
end

if map[i2][i+offsetx]>0 then
mapobjs[i2][i]:addEventListener( "touch", removenote )
end

mapobjs[i2][i].x=(i*32)-16
mapobjs[i2][i].y=((i2-1)*32)+15



mapobjs[i2][i].arrayx=i
mapobjs[i2][i].arrayy=i2
group:insert( mapobjs[i2][i] )
end
end

notesdisplay:toFront( )
topbar:toFront( )


if playbutton~=nil then
playbutton:toFront( )
end
if stopbutton~=nil then
stopbutton:toFront( )
end

helpbutton:toFront( )
notechanger:toFront( )
nextpage:toFront( )
backpage:toFront( )
notesdisplay.y=223
notesdisplay.y=notesdisplay.y+32
group.y=group.y+32
savebutton:toFront( )
loadbutton:toFront( )
upbutton:toFront( )
downbutton:toFront( )
pagetext:toFront( )
playbutton2:toFront( )
countnotes:toFront()
if daline~=nil then
daline:toFront( )
end
end



function playnote()
for i=1, 14 do
if map[i][currentnote]>0 then
if map[i][currentnote]==1 then
audio.play( pianonotes[i] )
elseif map[i][currentnote]==2 then
audio.play( pianosharp[i] )
elseif map[i][currentnote]==3 then
audio.play( pianoflat[i] )
elseif map[i][currentnote]==4 then
audio.play( bass[i] )
elseif map[i][currentnote]==5 then
audio.play( basssharp[i] )
elseif map[i][currentnote]==6 then
audio.play( bassflat[i] )
elseif map[i][currentnote]==7 then
audio.play( drum[i] )
end

end
end

daline.x=daline.x+32
print (daline.x)
if daline.x==464 then
offsetx=offsetx+14
page=page+1
daline.x=16
refreshpage()
end

currentnote=currentnote+1
if currentnote==401 then

playing=false
stopbutton:removeSelf()
stopbutton=nil
playbutton=display.newImage( "Play.png" )
playbutton.x=16
playbutton.y=16
playbutton:addEventListener( "touch", startplaying )
currentnote=1
daline:removeSelf()
daline=nil
return
end
datimer=timer.performWithDelay( (150.0*(1.0/(bpm/100.0))), playnote )
end

function stop(event)
if ( event.phase == "ended" ) then
if playing==true then
playing=false
stopbutton:removeSelf()
stopbutton=nil
playbutton=display.newImage( "Play.png" )
playbutton.x=16
playbutton.y=16
playbutton:addEventListener( "touch", startplaying )
timer.cancel( datimer )
currentnote=1
daline:removeSelf()
daline=nil
else
native.showAlert( "Wow", "Somehow you managed to press stop when the playing variable is false.\nInteresting.\nI'll fix the play button...")
playing=false
stopbutton:removeSelf()
stopbutton=nil
playbutton=display.newImage( "Play.png" )
playbutton.x=16
playbutton.y=16
playbutton:addEventListener( "touch", startplaying )
currentnote=1
end
end
end

function startplaying(event, dc)
if ( event.phase == "ended" ) then
if playing==false then

daline=display.newRect( -16, 174, 32, 320-32 )
daline.alpha=.75
playbutton:removeSelf()
playbutton=nil

if dc~=nil then

else
page=1
offsetx=0
refreshpage()
pagetext.text=("Page: " .. page)
end

currentnote=1


stopbutton=display.newImage( "Stop.png" )
stopbutton.x=16
stopbutton.y=16
stopbutton:addEventListener( "touch", stop )

datimer=timer.performWithDelay( (150.0*(1.0/(bpm/100.0))), playnote )
playing=true
end
end
end



function changenote(event)
if ( event.phase == "ended" ) then
note=note+1
if note==9 then
note=1
end

notechanger:removeSelf()
notechanger=nil

if note==1 then
notechanger=display.newImage("PianoNote.png")
elseif note==2 then
notechanger=display.newImage("PianoSharp.png")
elseif note==3 then
notechanger=display.newImage("PianoFlat.png")
elseif note==4 then
notechanger=display.newImage("Bass.png")
elseif note==5 then
notechanger=display.newImage("SharpBass.png")
elseif note==6 then
notechanger=display.newImage("FlatBass.png")
elseif note==7 then
notechanger=display.newImage("Drum.png")
elseif note==8 then
notechanger=display.newImage("PianoBlank.png")
end

notechanger.x=60
notechanger.y=16

notechanger:addEventListener( "touch", changenote )
end
end

function textListener2(event)
if ( event.phase == "ended" or event.phase == "submitted" ) then
savename=event.target.text
elseif ( event.phase == "editing" ) then
savename=event.target.text
end
end

function gotosave()
print "Gotosave"
savebutton:removeEventListener( "tap", gotosave )

if playing==false then
playbutton.x=-200
else
stopbutton.x=-200
end

notechanger.x=-200
backpage.x=-200
nextpage.x=-200
savebutton.x=16
loadbutton.x=-200
upbutton.x=-200
downbutton.x=-200
playbutton2.x=-200

savefield = native.newTextField( 130, 16, 180, 30 )

savefield:addEventListener( "userInput", textListener2 )
savefield.placeholder = "Song name"

timer.performWithDelay( 100, giveabilitytosave)
end

function giveabilitytosave()
savebutton:addEventListener( "tap", dosave )
end
function giveabilitytosavemenu()
savebutton:addEventListener( "tap", gotosave )
end

function dosave()
print "gonna da save"
savebutton:removeEventListener( "tap", dosave )
timer.performWithDelay( 100, giveabilitytosavemenu )
save(savename)
end

function save(name)
savestring=""
print "Starting saving..."

--loadstring=loadFile("index.txt")
--saveFile("index.txt", (loadstring .. name .. "="))

savebutton.x=-500

savestring="390"

for i=1, 14 do
for i3=1, 400 do
savestring=(savestring .. map[i][i3])
end
end

saveFile(name .. ".txt", savestring)

addindex(name)

native.showAlert( "Done!", "It was saved! Yay!" )
savebutton.x=192

notesdisplay.x=466
notesdisplay.y=223
topbar.y=16
topbar.x=240


if playing==false then
playbutton.x=16
playbutton.x=16
playbutton.y=16
else
stopbutton.x=16
end




--helpbutton.x=464
helpbutton.y=16
notechanger.x=60
notechanger.y=16
nextpage.x=148
nextpage.y=16
backpage.x=104
backpage.y=16
savebutton.x=192
savebutton.y=16
--loadbutton.x=236
--loadbutton.y=16
upbutton.x=280
upbutton.y=16
downbutton.x=324
downbutton.y=16
playbutton2.x=236
savefield:removeSelf()
savefield=nil
end

function load(dafile)
indexstring = loadFile( "index.txt" )
print (indexstring)
loadstring=loadFile(dafile .. ".txt")

for i=1, 14 do
for i3=1, 400 do
map[i][i3]=tonumber(loadstring:sub( (i3+((i-1)*400))+3,(i3+((i-1)*400)+3) ))
end
end
native.showAlert( "Done!", (dafile .. " was loaded! Yay!") )
refreshpage()
end

function goup(event)
if ( event.phase == "ended" ) then
movescreen(2)
end
end
function godown(event)
if ( event.phase == "ended" ) then
movescreen(1)
end
end

function runtimetouch(event)
if (event.phase == "ended") then

for i=1, 14 do
for i3=1, 14 do
donespots[i][i3]=0
end
end

end
end

function play2()

if playing==false then

playbutton:removeSelf()
playbutton=nil

stopbutton=display.newImage( "Stop.png" )
stopbutton.x=16
stopbutton.y=16
stopbutton:addEventListener( "touch", stop )

daline=display.newRect( -16, 174, 32, 320-32 )
daline.alpha=.75

currentnote=(14*(page-1))+1
print (currentnote)

datimer=timer.performWithDelay( (150.0*(1.0/(bpm/100.0))), playnote )
playing=true
end

end

function play()

notesdisplay=display.newImage( "notes.png" )
notesdisplay.x=466
notesdisplay.y=223
 topbar=display.newImage( "TopBar.png" )
topbar.y=16
topbar.x=240
 playbutton=display.newImage( "Play.png" )
playbutton.x=16
playbutton.y=16
 helpbutton=display.newImage( "Help.png" )
--helpbutton.x=464
helpbutton.x=-200
helpbutton.y=16
notechanger=display.newImage("PianoNote.png")
notechanger.x=60
notechanger.y=16
 nextpage=display.newImage( "ForwardPage.png" )
nextpage.x=148
nextpage.y=16
 backpage=display.newImage( "BackPage.png" )
backpage.x=104
backpage.y=16
 savebutton=display.newImage( "Save.png" )
savebutton.x=192
savebutton.y=16

 loadbutton=display.newImage( "Load.png" )
loadbutton.x=236
--loadbutton.y=16
loadbutton.y=-32

upbutton=display.newImage("Up.png")
upbutton.x=280
upbutton.y=16

downbutton=display.newImage("Down.png")
downbutton.x=324
downbutton.y=16

countnotes=display.newImage("Count.png")
countnotes.x=450
countnotes.y=16

playbutton2=display.newImage("Play2.png")
playbutton2.x=236
playbutton2.y=16
playbutton2:addEventListener( "tap", play2 )

pagetext=display.newText( "Page: " .. page, 390, 16, native.systemFont, 13 )
pagetext:setFillColor( 0,0,0 )
for i2=1, 14 do
for i=1, 14 do
mapobjs[i2][i]=display.newImage("blank.png")
mapobjs[i2][i].x=(i*32)-16
mapobjs[i2][i].y=((i2-1)*32)+15
mapobjs[i2][i]:addEventListener( "touch", addnote )
mapobjs[i2][i].arrayx=i
mapobjs[i2][i].arrayy=i2
group:insert( mapobjs[i2][i] )
end
end

refreshpage()

notesdisplay:toFront( )
topbar:toFront( )
playbutton:toFront( )
helpbutton:toFront( )
notechanger:toFront( )
--group.y=group.y+32
--notesdisplay.y=notesdisplay.y+32
notechanger:addEventListener( "touch", changenote )
playbutton:addEventListener( "touch", startplaying )
nextpage:toFront( )
backpage:toFront( )
nextpage:addEventListener( "touch", nextpagef )
backpage:addEventListener( "touch", backpagef )
savebutton:toFront( )
loadbutton:toFront( )
savebutton:addEventListener( "tap", gotosave )
loadbutton:addEventListener( "tap", load )
countnotes:addEventListener( "tap", countnotesf )
upbutton:toFront( )
downbutton:toFront( )
upbutton:addEventListener( "touch", goup )
downbutton:addEventListener( "touch", godown )
Runtime:addEventListener( "touch", runtimetouch )
pagetext:toFront( )
playbutton2:toFront( )
countnotes:toFront()

end

function gotoplay()
titlebackground:removeSelf()
titlebackground=nil
credits:removeSelf()
credits=nil
playbutton:removeSelf()
playbutton=nil
openbutton:removeSelf()
openbutton=nil
optionsbutton:removeSelf()
optionsbutton=nil
bpmfield:removeSelf()
bpmfield=nil
importbutton:removeSelf()
importbutton=nil
exportbutton:removeSelf()
exportbutton=nil
play()
end

function exportnextstep()
print "This is the next step in exporting."

loadstring=loadFile(chosensong .. ".txt")

export(chosensong)

infotext1=display.newText( "The song has been exported.", 130, 32 )
infotext2=display.newText( "On a computer, click import, then enter " .. chosensong, 200, 48 )
infotext3=display.newText( "", 200, 70, native.systemFont, 13 )
infotext3:setFillColor( 0,255,0 )
infotext4=display.newText( "", 230, 170 )
end

function gotoexport()
titlebackground:removeSelf()
titlebackground=nil
credits:removeSelf()
credits=nil
playbutton:removeSelf()
playbutton=nil
openbutton:removeSelf()
openbutton=nil
optionsbutton:removeSelf()
optionsbutton=nil
bpmfield:removeSelf()
bpmfield=nil
importbutton:removeSelf()
importbutton=nil
exportbutton:removeSelf()
exportbutton=nil
getsongexport()
end

function export(daname)

headers["Content-Type"] = "application/x-www-form-urlencoded"
headers["Accept-Language"] = "en-US"

local body = ("code=936&name=" .. daname .. "&data=" .. loadstring)

local params = {}
params.headers = headers
params.body = body

network.request( "http://mylegguy.x10.mx/GrowtopiaMusicSimulatorAndroid/uploadimport.php", "POST", networkListener, params )
end

function gototitleopen()
titlebackground:removeSelf()
titlebackground=nil
credits:removeSelf()
credits=nil
playbutton:removeSelf()
playbutton=nil
openbutton:removeSelf()
openbutton=nil
optionsbutton:removeSelf()
optionsbutton=nil
bpmfield:removeSelf()
bpmfield=nil
importbutton:removeSelf()
importbutton=nil
exportbutton:removeSelf()
exportbutton=nil
getsongload()
end

function returnsong(event)
chosensong=event.target.text
whilenumber=1
prev=0
mytext1:removeSelf()
mytext1=nil
for i=1, table.maxn( mytext ) do
mytext[i]:removeSelf()
mytext[i]=nil
end

if delbutton~=nil then
delbutton:removeSelf()
delbutton=nil
end
if backbutton~=nil then
backbutton:removeSelf()
backbutton=nil
end

play()
load(chosensong)
end

function returnsongnoload(event)
chosensong=event.target.text
whilenumber=1
prev=0
mytext1:removeSelf()
mytext1=nil
for i=1, table.maxn( mytext ) do
mytext[i]:removeSelf()
mytext[i]=nil
end
exportnextstep()
end

function backdel()
mytext1.text="Tap the song you want to load."
backbutton:removeSelf()
backbutton=nil
delbutton=display.newImage("Del.png")
delbutton.x=332
delbutton.y=32
delbutton:addEventListener( "tap", startdel )

for i=1, table.maxn( mytext ) do
mytext[i]:addEventListener( "tap", returnsong )
mytext[i]:removeEventListener( "tap", delsong )
end

end

function delsong(event)
print "-===="
whilenumber=0
prev=0
loadstring=loadFile("index.txt")
print (loadstring)
while string.find( loadstring, "=", 1+prev )~=nil do
if loadstring:sub(1+prev,string.find( loadstring, "=", 1+prev )-1)==event.target.text then
saveFile("index.txt",string.gsub( loadstring, loadstring:sub(1+prev,string.find( loadstring, "=", 1+prev )), "" ))
print (string.len(string.gsub( loadstring, loadstring:sub(1+prev,string.find( loadstring, "=", 1+prev )), "" )))
--saveFile("index.txt", (loadstring:sub(1, prev) )
loadstring=loadFile(event.target.text)
saveFile("OneBackup.txt",loadstring)
saveFile((event.target.text .. ".txt"), "")
event.target.text=""
event.target:removeEventListener( "tap", delsong )
return
end
prev=string.find( loadstring, "=", 1+prev )
whilenumber=whilenumber+1
end
native.showAlert( "uh...", "Well, somehow you were able to select a song that was loaded from the index file...but I can't find it here. Wierd.")
end

function startdel()
	delbutton:removeSelf()
delbutton=nil
backbutton=display.newImage( "Back.png" )
backbutton.x=332
backbutton.y=64
backbutton:addEventListener( "tap", backdel )
mytext1.text="Tap the song you want to DELETE."
mytext1.x=150

whilenumber=1
prev=0

while string.find( loadstring, "=", 1+prev )~=nil do
mytext[whilenumber]:removeEventListener( "tap", returnsong )
mytext[whilenumber]:addEventListener( "tap", delsong )
prev=string.find( loadstring, "=", 1+prev )
whilenumber=whilenumber+1
end

end

function getsongload()
whilenumber=1
prev=0
loadstring=loadFile("index.txt")
mytext1=display.newText( "Tap the song you want to load", 120, 20 )
while string.find( loadstring, "=", 1+prev )~=nil do
mytext[whilenumber]=display.newText( "", 120, (20*whilenumber)+40 )
mytext[whilenumber].text=loadstring:sub(1+prev,string.find( loadstring, "=", 1+prev )-1)
mytext[whilenumber]:addEventListener( "tap", returnsong )
prev=string.find( loadstring, "=", 1+prev )
whilenumber=whilenumber+1
end
print (string.find( loadstring, "=", 1 ))

delbutton=display.newImage("Del.png")
delbutton.x=332
delbutton.y=32
delbutton:addEventListener( "tap", startdel )
end

function getsongexport()
whilenumber=1
prev=0
loadstring=loadFile("index.txt")
mytext1=display.newText( "Tap the song you want to export.", 150, 30 )
while string.find( loadstring, "=", 1+prev )~=nil do
mytext[whilenumber]=display.newText( "", 120, (20*whilenumber)+50 )
mytext[whilenumber].text=loadstring:sub(1+prev,string.find( loadstring, "=", 1+prev )-1)
mytext[whilenumber]:addEventListener( "tap", returnsongnoload )
prev=string.find( loadstring, "=", 1+prev )
whilenumber=whilenumber+1
end
end

local function textListener( event )
if ( event.phase == "began" ) then
bpm=tonumber(event.target.text)
elseif ( event.phase == "ended" or event.phase == "submitted" ) then
bpm=tonumber(event.target.text)
if bpm>200 then
native.showAlert( "Oops. >", "The max bpm is 200. Options file not saved." )
return
end
if bpm<20 then
native.showAlert( "Oops. <", "The minimum bpm is 20. Options file not saved." )
return
end
saveFile("options.txt",tostring(bpm))
elseif ( event.phase == "editing" ) then
bpm=tonumber(event.target.text)
end
end

function creditssecret()
credits.text="You found a secret! Good job!"
end

function title()
titlebackground=display.newImage("Title.png")
titlebackground.x=240
titlebackground.y=160
playbutton=display.newImage("PlayButton.png")
playbutton.x=120
playbutton.y=170
openbutton=display.newImage( "OpenButton.png" )
openbutton.x=320
openbutton.y=170
optionsbutton=display.newImage( "OptionsButton.png" )
optionsbutton.x=display.contentWidth/2
--optionsbutton.y=260
optionsbutton.y=500
playbutton:addEventListener( "tap", gotoplay )
openbutton:addEventListener( "tap", gototitleopen )
exportbutton=display.newImage( "Export.png" )
exportbutton.x=400
exportbutton.y=275
importbutton=display.newImage( "Import.png" )
importbutton.x=64
importbutton.y=275
bpmfield = native.newTextField( 230, 250, 180, 30 )
bpmfield:addEventListener( "userInput", textListener )
bpmfield.inputType = "number"
bpmfield.placeholder = "100"
bpmfield.text=tostring(bpm)
exportbutton:addEventListener( "tap", gotoexport )
importbutton:addEventListener( "tap", import )
credits=display.newText( "                   Credits-\nMyLegGuy-Programming\nHonestyCow-Matched files to notes\nv1.9", 230, 100, native.systemFont, 14 )
credits:setFillColor( 0,0,0 )
credits:addEventListener( "tap", creditssecret )
end

function loadsettings()
loadstring=loadFile("options.txt")
bpm = tonumber(loadstring:sub(1,3))
if bpm==nil then
bpm=100
end
end

function addindex(toadd)
whilenumber=0
prev=0
loadstring=loadFile("index.txt")
print "=="
print (toadd)

while string.find( loadstring, "=", 1+prev )~=nil do
print (loadstring:sub(1+prev,string.find( loadstring, "=", 1+prev )-1))
if loadstring:sub(1+prev,string.find( loadstring, "=", 1+prev )-1)==toadd then
return
end
prev=string.find( loadstring, "=", 1+prev )
whilenumber=whilenumber+1
end
print "so... it got here..."
loadstring=(loadstring .. toadd .. "=")
print (loadstring)
saveFile("index.txt", loadstring)
loadstring=""
end

function downloadlistener(event)
 if ( event.isError ) then
        print( "Network error - download failed" )
native.showAlert( "Sad face.", "Noooo! There was a network error! Song not downloaded.." )
    elseif ( event.phase == "began" ) then
        print( "Progress Phase: began" )
    elseif ( event.phase == "ended" ) then
       native.showAlert( "Done!", "Yey! The song was imported successfully!" )
addindex(toimport) 
end
end

function doimport()
network.download( "http://mylegguy.x10.mx/GrowtopiaMusicSimulatorAndroid/" .. toimport .. ".txt", "GET", downloadlistener, (toimport .. ".txt") )
importfield:removeSelf()
importfield=nil
title()
end

function textListener3(event)
if ( event.phase == "ended" or event.phase == "submitted" ) then
toimport=event.target.text
doimport()
end
end

function import()
titlebackground:removeSelf()
titlebackground=nil
credits:removeSelf()
credits=nil
playbutton:removeSelf()
playbutton=nil
openbutton:removeSelf()
openbutton=nil
optionsbutton:removeSelf()
optionsbutton=nil
bpmfield:removeSelf()
bpmfield=nil
importbutton:removeSelf()
importbutton=nil
exportbutton:removeSelf()
exportbutton=nil

importfield = native.newTextField( 230, 250, 300, 30 )
importfield:addEventListener( "userInput", textListener3 )
importfield.placeholder = "Song you want to download?"

end

local function updatenetworkListener2( event )
    if ( event.isError ) then
        print( "Network error!" )
print ("Whatever.")
    else
        print ( "RESPONSE: " .. event.response )      
native.showAlert( "Update avalible!", event.response )
end
end

local function updatenetworkListener( event )
    if ( event.isError ) then
        print( "Network error!" )
print ("Whatever.")
    else
        print ( "RESPONSE: " .. event.response )      
if tonumber(event.response)~=nil then
        
        if tonumber(event.response)>version then
        print ("update avaliblee!!")

network.request( "http://mylegguy.x10.mx/GMSandroidinfo.html", "GET", updatenetworkListener2, params )
        end
        
print ( "RESPONSE: " .. event.response )

end

    end
end

function checkforupdate()
headers["Content-Type"] = "application/x-www-form-urlencoded"
headers["Accept-Language"] = "en-US"

local params = {}
params.headers = headers

network.request( "http://mylegguy.x10.mx/GMSandroid.html", "GET", updatenetworkListener, params )
end

checkforupdate()

loadsettings()

title()


