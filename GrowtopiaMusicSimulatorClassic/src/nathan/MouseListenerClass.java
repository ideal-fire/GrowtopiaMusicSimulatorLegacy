package nathan;

import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import java.awt.event.MouseWheelEvent;
import java.awt.event.MouseWheelListener;
import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.MalformedURLException;
import java.net.URL;

import javax.imageio.ImageIO;
import javax.swing.JFileChooser;
import javax.swing.JOptionPane;
import javax.swing.filechooser.FileNameExtensionFilter;

public class MouseListenerClass implements MouseListener, MouseWheelListener, MouseMotionListener{

	static boolean done = false;
	
	static int mousex = 0;
	static int mousey = 0;
	
	static int mouse = 0;
	
	MainClass mca;
	
	ze_buttons playButton;
	
	public MouseListenerClass(MainClass mc, ze_buttons playButton){
		mca=mc;
		this.playButton = playButton;
	}
	
	@Override
	public void mouseClicked(MouseEvent e) {
		
		

	}

	@Override
	public void mouseEntered(MouseEvent q) {
		


	}

	@Override
	public void mouseExited(MouseEvent e) {
		

	}
	
	
	
	
	

	public void mousePressed(MouseEvent q) {
		mousex = q.getX();
		mousey = q.getY();
		
		System.out.println("asaaa");
		
		if (mca.previewing){
			
			if (mousex>32 && mousex<198 && mousey>32 && mousey<83){
				mca.themeshop=true;
				mca.previewing=false;
			}
			return;
		}
		
		if (mca.themeshop){
			if (mousex<166 && mousey<51){
				mca.themeshop=false;
				mca.previewing=false;
				mca.title=true;
				mca.daint=0;
			}
			for(int i=0; i<mca.daint/2; i++){
				if (mousex>200 && mousey>(i*17)-1 && mousey<(i*17)+16){
	        		Object[] optionsb = {"Preview Theme",
	                        "Download theme", "Never mind."};
	        int n = JOptionPane.showOptionDialog(null,
	        "What do you want to do with this theme?",
	        "What do ya wanna do?",
	        JOptionPane.YES_NO_OPTION,
	        JOptionPane.QUESTION_MESSAGE,
	        null,     //do not use a custom Icon
	        optionsb,  //the titles of buttons
	        optionsb[2]); //default button title
					System.out.println("Chose "+mca.themestrings[i*2]);
					
System.out.println(n);
					
					if (n==0){
						mca.previewing=true;
						mca.themeshop=false;
						try {
							mca.previewimage = ImageIO.read(new URL("http://www.mylegguy.x10.mx/GrowtopiaMusicSimulatorThemes/"+mca.themestrings[(i*2)+1]));
						} catch (MalformedURLException e) {
							JOptionPane.showMessageDialog(null,
								    "Something went wrong. MalformedURLException: "+e,
								    "Confused face...",
								    JOptionPane.WARNING_MESSAGE);
							e.printStackTrace();
						} catch (IOException e) {
							// TODO Auto-generated catch block
							JOptionPane.showMessageDialog(null,
								    "Something went horribly wrong. IOException: "+e,
								    "Sad face.",
								    JOptionPane.WARNING_MESSAGE);
							e.printStackTrace();
						}
					
					}
					
					if (n==1){
						System.out.println("Download from: "+"http://www.mylegguy.x10.mx/GrowtopiaMusicSimulatorThemes/"+mca.themestrings[(i*2)+1]);
					try {
					
						//mca.themestrings[(i*2)+1]
						JFileChooser fileChooser = new JFileChooser();
						fileChooser.setDialogTitle("Where do you wanna save the file?");   
						
						File workingDirectory = new File(System.getProperty("user.dir"));
						fileChooser.setCurrentDirectory(workingDirectory);
						
						fileChooser.setSelectedFile(new File(mca.themestrings[(i*2)+1]));
						
						int userSelection = fileChooser.showSaveDialog(null);
						 
						System.out.println("========");
						System.out.println(fileChooser.getSelectedFile().getAbsolutePath());
						
						if (userSelection == JFileChooser.APPROVE_OPTION) {
						    
							
							if (!fileChooser.getSelectedFile().getAbsolutePath().endsWith(".png")){
								JOptionPane.showMessageDialog(null,
									    "You forgot the .png. I'll add it for you.");
								MainClass.saveImage("http://www.mylegguy.x10.mx/GrowtopiaMusicSimulatorThemes/"+mca.themestrings[(i*2)+1], fileChooser.getSelectedFile().getAbsolutePath()+".png");
								JOptionPane.showMessageDialog(null,
									    "The theme was saved at"+fileChooser.getSelectedFile().getAbsolutePath()+".png"+".\nUse it by going to the settings, choosing Custom Theme, and choosing "+fileChooser.getSelectedFile().getAbsolutePath()+".png"+".");
							}
							else
							{
								MainClass.saveImage("http://www.mylegguy.x10.mx/GrowtopiaMusicSimulatorThemes/"+mca.themestrings[(i*2)+1], fileChooser.getSelectedFile().getAbsolutePath());
								JOptionPane.showMessageDialog(null,
									    "The theme was saved at"+fileChooser.getSelectedFile().getAbsolutePath()+".\nUse it by going to the settings, choosing Custom Theme, and choosing "+fileChooser.getSelectedFile().getAbsolutePath()+".");
							}
							
			        		Object[] optionsc = {"Yah",
			                        "Nah"};
			        int n2 = JOptionPane.showOptionDialog(null,
			        "Do you want to set this theme as your custom theme right now?",
			        "A question",
			        JOptionPane.YES_NO_OPTION,
			        JOptionPane.QUESTION_MESSAGE,
			        null,     //do not use a custom Icon
			        optionsc,  //the titles of buttons
			        optionsc[1]); //default button title
							
			        if (n2==0){
			        	mca.theme=5;
			        	if (!fileChooser.getSelectedFile().getAbsolutePath().endsWith(".png")){
			        		mca.custompath=fileChooser.getSelectedFile().getAbsolutePath()+".png";
			        	}
			        	else
			        	{
			        		mca.custompath=fileChooser.getSelectedFile().getAbsolutePath();
			        	}
			        	
							mca.saveoptions();
							JOptionPane.showMessageDialog(null,
								    "Done.");
			        }
			        mca.custom = ImageIO.read(new File(mca.custompath));
			        
							
						}else
						{
							JOptionPane.showMessageDialog(null,
								    "Uh... what did you do? You may have pressed cancel instead of save or something...",
								    "Not amused face.",
								    JOptionPane.WARNING_MESSAGE);
						}
						
						
					} catch (IOException e) {
						// TODO Auto-generated catch block
						JOptionPane.showMessageDialog(null,
							    "The file was not successfully downloaded.",
							    "Sad face.",
							    JOptionPane.WARNING_MESSAGE);
						e.printStackTrace();
					}
					
					}
				}
			}
		return;
		}
		
		if (mca.movedabuttons){
			
			
			
			if (mousex>32 && mousex<198 && mousey>32 && mousey<83){
			
				if (mca.saveButton.getx()<0 | mca.saveButton.gety()<0 | mca.loadButton.getx()<0 | mca.loadButton.gety()<0 | mca.leftButton.getx()<0 | mca.leftButton.gety()<0 | mca.rightButton.getx()<0 | mca.rightButton.gety()<0 | mca.playButton.getx()<0 | mca.playButton.gety()<0 )
				{
					
					JOptionPane.showMessageDialog(null,
						    "None of the buttons can be partially off screen.",
						    "FIX IT!",
						    JOptionPane.WARNING_MESSAGE);
					return;
				}
				
				mca.movedabuttons=false;
				mca.title=true;
			mca.saveoptions();
			return;
			}
			
			
			if(mousex>mca.saveButton.getx() && mousey>mca.saveButton.gety() && mousex<mca.saveButton.getwidthEdge() && mousey<mca.saveButton.getheightEdge()){
				mca.moveselect=1;
				return;
			}
			
			if(mousex>mca.loadButton.getx() && mousey>mca.loadButton.gety() && mousex<mca.loadButton.getwidthEdge() && mousey<mca.loadButton.getheightEdge()){
				mca.moveselect=2;
				return;
			}
			if(mousex>mca.leftButton.getx() && mousey>mca.leftButton.gety() && mousex<mca.leftButton.getwidthEdge() && mousey<mca.leftButton.getheightEdge())
			{
				mca.moveselect=3;
				return;
			}
			if(mousex>mca.rightButton.getx() && mousey>mca.rightButton.gety() && mousex<mca.rightButton.getwidthEdge() && mousey<mca.rightButton.getheightEdge())
			{
				mca.moveselect=4;
				return;
			}
			
			if(mousex>playButton.getx() && mousey>playButton.gety() && mousex<playButton.getwidthEdge() && mousey<playButton.getheightEdge())
			{
				mca.moveselect=5;
				return;
			}
			
			if (mca.moveselect!=0){
				mca.moveselect=0;
			}
			
			
		}
		
		if (mca.playing)
		{
			if(mousex>playButton.getx() && mousey>playButton.gety() && mousex<playButton.getwidthEdge() && mousey<playButton.getheightEdge())
			{
				System.out.println("Deactivated - via mouse");
				mca.running=true;
				mca.playing=false;
				mca.pianox=1;
				mca.offset=mca.oldoffset;
				mca.page=((mca.offset+25))/25;
				if (mca.closesounds==true){
			         for(int i=0; i<mca.currentclip-1; i++){
			              mca.clips[i].close();
			              System.out.println("Closed sound"+i+" .");
			         }
			       mca.currentclip=0;
				}
				return;
			}
			return;
		}
		
		

		if (mca.title){
			
			System.out.println(mousex);
			System.out.println(mousey);
			//g.drawImage(playbutton,300,300,this);
			//g.drawImage(optionsbutton,300,418,this);
			
			//g.drawImage(movebuttonsbutton,26,418,this);
			
			//g.drawImage(getcustomthemesbutton,26,300,this);
			
			//g.drawImage(importbutton,574,400,this);
			
			if (mousex>574 && mousex<745 && mousey>400 && mousey<468){
				String inputValue = JOptionPane.showInputDialog("Input the song you want to import.");
				
				
					JFileChooser chooser;
					
					chooser = new JFileChooser(); 
				    chooser.setCurrentDirectory(new java.io.File("."));
				    chooser.setDialogTitle("What do you want to save the imported song as?");
				   // chooser.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
				    //
				    // disable the "All files" option.
				    //
				    chooser.setAcceptAllFileFilterUsed(false);
				    //    
				    if (chooser.showSaveDialog(null) == JFileChooser.APPROVE_OPTION) { 
				      System.out.println("getCurrentDirectory(): " 
				         +  chooser.getCurrentDirectory());
				      System.out.println("getSelectedFile() : " 
				         +  chooser.getSelectedFile());
				    //File file = new File ("" + chooser.getSelectedFile());
				      
				    }
				    else {
				      System.out.println("No Selection ");
				    return;  
				    }
				try {
					
					
					if (!chooser.getSelectedFile().getName().endsWith(".mylegguy")){
						JOptionPane.showMessageDialog(null,
							    "Ya forgot the .mylegguy. I'll add that for you.",
							    "WARNING, WARNING",
							    JOptionPane.WARNING_MESSAGE);
						saveUrl(new File(chooser.getSelectedFile()+".mylegguy"),"http://mylegguy.x10.mx/GrowtopiaMusicSimulatorAndroid/"+inputValue+".txt");
					}
					else
					{
						saveUrl(chooser.getSelectedFile(),"http://mylegguy.x10.mx/GrowtopiaMusicSimulatorAndroid/"+inputValue+".txt");
					}
					
					
					
					System.out.println("Done");
		 
				} catch (IOException e) {
					e.printStackTrace();
				}
				
				/*
				 *} catch (MalformedURLException e) {
					// TODO Auto-generated catch block
					
					JOptionPane.showMessageDialog(null,
						    "Eggs are not supposed to be green, I mean there was an error when importing.",
						    "Wait a second..!",
						    JOptionPane.WARNING_MESSAGE);
					
					e.printStackTrace();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					JOptionPane.showMessageDialog(null,
						    "A different error!",
						    "NOO!",
						    JOptionPane.WARNING_MESSAGE);
					e.printStackTrace();
				}
				 */
				
			}
			
			if (mousex>26 && mousex<236 && mousey>300 && mousey<383){
				System.out.println("Click on da theme shop");
			mca.themeshop=true;
			mca.title=false;
			mca.gotothemeshop();
			}
			
			
			if (mousex>26 && mousex<236 && mousey>418 && mousey<501){
				mca.title=false;
				mca.movedabuttons=true;
			}
			
			if (mousex>574 && mousex<784 && mousey>300 && mousey<383){
				
				try {
					mca.load(null);
				} catch (Exception e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				mca.gotoplay=true;
			}
			
			if (mousex>299 && mousey>299 && mousex<509 && mousey<299+83)
			{
				mca.gotoplay=true;
			}
			
			if (mousex>299 && mousey>417 && mousex<509 && mousey<418+83)
			{
				mca.options=true;
				mca.title=false;
			}
			
		}

		if (mca.options){
			
			//g.drawImage(colorfullthumb,32,36,this);
			//g.drawImage(classicthumb,280,186,this);
			//g.drawImage(backgroundthumb,528,336,this);
			
			//g.drawImage(loadbutton,574,300,this);
			
			
			
			
			
			if (mousex>=32 && mousex<=32+236 && mousey>=36 && mousey<=36+206)
			{
				mca.theme=1;
				mca.options=false;
				mca.title=true;
			}
			
			//g.fillRect(532, 128, 32, 32);
			if (mousex>532 && mousex<564 && mousey>128 && mousey<160)
			{
				if (mca.closesounds==false){mca.closesounds=true;} else {mca.closesounds=false;}
			}
			
			if (mousex>=280 && mousex<=280+236 && mousey>=186 && mousey<=186+206)
			{
				mca.theme=2;
				mca.options=false;
				mca.saveoptions();
				mca.title=true;
			}
			if (mousex>=528 && mousex<=528+236 && mousey>=336 && mousey<=336+206)
			{
				mca.theme=3;
				mca.options=false;
				mca.saveoptions();
				mca.title=true;
			}
			//g.drawImage(classicthumb,32,300,this);
			if (mousex>=32 && mousex<=32+233 && mousey>=300 && mousey<=300+166)
			{
				mca.theme=4;
				mca.options=false;
				mca.saveoptions();
				mca.title=true;
			}
			//g.fillRect(750, 32, 32, 32);
			//g.fillRect(750, 80, 32, 32);
			
			if (mousex>750 && mousex<782 && mousey>32 && mousey<64){
				//if (mca.dopreload==false){mca.dopreload=true;} else {mca.dopreload=false;}
				String inputValue = JOptionPane.showInputDialog("Input the beats per minute you want (BPM)");
				
				try{
				mca.bpm = Integer.parseInt(inputValue);
				System.out.println("The new bpm is "+mca.bpm);
				
				if (mca.bpm>200){
					mca.bpm=200;
					JOptionPane.showMessageDialog(null,
						    "The maximum BPM is 200.",
						    "Oops. >",
						    JOptionPane.WARNING_MESSAGE);
				
				}
				if (mca.bpm<20){
					mca.bpm=20;
					JOptionPane.showMessageDialog(null,
						    "The minimum BPM is 20.",
						    "Oops. <",
						    JOptionPane.WARNING_MESSAGE);
				}
				
				}
				catch(NumberFormatException nfe){
					JOptionPane.showMessageDialog(null,
						    "Whatever you enterd wasn't a number. Sorry.",
						    "Oops.",
						    JOptionPane.WARNING_MESSAGE);
				}
				
			}
			
			if (mousex>750 && mousex<782 && mousey>80 && mousey<112){
				if (mca.playOnPlace==false){mca.playOnPlace=true;} else {mca.playOnPlace=false;}
			}
			
			//g.drawImage(customthumb,600,170,this);
			if (mousex>600 && mousex<679 && mousey>170 && mousey<246){
				
			    @SuppressWarnings("unused")
				InputStream is = null;
			      @SuppressWarnings("unused")
				int i;
			      @SuppressWarnings("unused")
				char c;
			      
				    JFileChooser chooser = new JFileChooser();
				    chooser.setCurrentDirectory(new java.io.File("."));
				    FileNameExtensionFilter filter = new FileNameExtensionFilter(
				        ".png files", "png");
				    chooser.setFileFilter(filter);
				    @SuppressWarnings("unused")
					int returnVal = chooser.showOpenDialog(chooser);

				       try {
						mca.custom = ImageIO.read(chooser.getSelectedFile());
					} catch (IOException e) {
						JOptionPane.showMessageDialog(null, "Nooo! An error! This is your fault!", "Error! Is your file a GIF, PNG, JPEG, BMP, or WBMP (What is a WBMP? I don't know)", JOptionPane.INFORMATION_MESSAGE);
						e.printStackTrace();
					}
				       
						mca.custompath=chooser.getSelectedFile().getAbsolutePath();
				       mca.theme=5;
						mca.options=false;
						mca.saveoptions();
						mca.title=true;

			}
			
			//g.fillRect(750, 128, 32, 32);
			if (mousex>750 && mousex<782 && mousey>128 && mousey<160){
				if (mca.line==false){mca.line=true;} else {mca.line=false;}
			}
			
			
		}
		
		
		if (mca.running | mca.playing){
			/*
			g.drawImage(spr_save_button,60,460,this);
			g.drawImage(spr_load_button,60,498,this);
			//p.x=160;
			//p.y=460;
			g.drawImage(spr_left_button,230,480,this);
			g.drawImage(spr_right_button,284,480,this);
			*/
			

			if(mousex>mca.saveButton.getx() && mousey>mca.saveButton.gety() && mousex<mca.saveButton.getwidthEdge() && mousey<mca.saveButton.getheightEdge()){
				mca.save(null);
			}
			//if (mousex>60 && mousex<92 && mousey>498 && mousey<530){
			if(mousex>mca.loadButton.getx() && mousey>mca.loadButton.gety() && mousex<mca.loadButton.getwidthEdge() && mousey<mca.loadButton.getheightEdge()){
			try {
					mca.load(null);
				} catch (Exception e) {
					JOptionPane.showMessageDialog(null, "Hey moron, this is an error. plz spam my thread wit repliez telling me to fixx!", "errorz", JOptionPane.INFORMATION_MESSAGE);
					e.printStackTrace();
				}
			}
			if(mousex>mca.leftButton.getx() && mousey>mca.leftButton.gety() && mousex<mca.leftButton.getwidthEdge() && mousey<mca.leftButton.getheightEdge())
			{
				if (mca.page!=1){mca.page-=1;
				mca.offset-=25;}
			}
			if(mousex>mca.rightButton.getx() && mousey>mca.rightButton.gety() && mousex<mca.rightButton.getwidthEdge() && mousey<mca.rightButton.getheightEdge())
			{
				if (mca.page!=16)
				{mca.page+=1;
				mca.offset+=25;}
			}
			
			
		}
		
		if (mca.running){
		
		if(mousex>playButton.getx() && mousey>playButton.gety() && mousex<playButton.getwidthEdge() && mousey<playButton.getheightEdge())
		{
			System.out.println("Activated - via mouse");
			
			if (mca.closesounds==true && mca.playOnPlace==true){
		         for(int i=0; i<mca.currentclip-1; i++){
		              mca.clips[i].close();
		              System.out.println("Closed sound"+i+" .");
		         }
		       mca.currentclip=0;
			}
			
			mca.oldoffset=mca.offset;
			mca.offset=0;
			mca.page=1;
			mca.running=false;
		mca.playing=true;
		mca.pianox=-1;
			return;
		}
		
		if(q.getButton() == MouseEvent.BUTTON1){
		mouse=1;
		System.out.println("Left");


		if (mca.selectmenu){mca.selectmenu=false;mca.selecting=false;}
		
		mca.PlacePiano2(mousex, mousey, NotePiano.note);		
	
		}
		else if (q.getButton() == MouseEvent.BUTTON3)
		{
			mouse=2;
			if (mca.selectmenu){mca.selectmenu=false;mca.selecting=false;}
			System.out.println("Right");

			
			mca.PlacePiano2(mousex, mousey, 0);		
		} else if (q.getButton() == MouseEvent.BUTTON2)
		{
			System.out.println("Middle clicl?");

			if (mca.running==true){
				System.out.println(mca.offset);
				System.out.println("Activated");
				if (mca.closesounds==true && mca.playOnPlace==true){
			         for(int i=0; i<mca.currentclip-1; i++){
			              mca.clips[i].close();
			              System.out.println("Closed sound"+i+" .");
			         }
			       mca.currentclip=0;
				}
				mca.oldoffset=mca.offset;
				mca.offset=mca.oldoffset;
				mca.running=false;
			mca.playing=true;
			mca.pianox=mca.offset;

			}else if(mca.playing==true){
			System.out.println("Deactivated");
			mca.running=true;
			mca.playing=false;
			mca.pianox=1;
			
			mca.offset=mca.oldoffset;
			mca.page=((mca.offset+25))/25;
			System.out.println(mca.offset);
			if (mca.closesounds==true){
		         for(int i=0; i<mca.currentclip-1; i++){
		              mca.clips[i].close();
		              System.out.println("Closed sound"+i+" .");
		         }
		       mca.currentclip=0;
			}
			}
			
			
			/*
			if (!mca.selecting){
			System.out.println("Middle");
mouse=3;
mca.selecting=true;
mca.selectx1=(int) Math.floor((mousex/32)+.5);	
mca.selecty1=(int) Math.floor((mousey/32)+.5);
			}else {
			
			mca.selectmenu=true;
			mca.selecting=false;	
			
			}
			*/
			
			
			}

		
	}
		

		

	}
		
		

	@Override
	public void mouseReleased(MouseEvent e) {
		

	}


	
	
	@Override
	public void mouseWheelMoved(MouseWheelEvent mw) {
		
		int rotations = mw.getWheelRotation();

//System.out.println("Scrolled.");
		
		if (rotations>0){
			NotePiano.note+=1;
			if (NotePiano.note==9){
				NotePiano.note=0;
			}
		}
		else
		{
			NotePiano.note-=1;
			if (NotePiano.note==-1){
				NotePiano.note=8;
			}
		}
		
	}

	@Override
	public void mouseDragged(MouseEvent q) {
		
		mousex = q.getX();
		mousey = q.getY();

		if (mca.movedabuttons){
			
			if (mca.moveselect==0)
			{
				return;
			}
			
			if (mca.moveselect==1){
				mca.saveButton.setx(mousex);
				mca.saveButton.sety(mousey);
			}
			if (mca.moveselect==2){
				mca.loadButton.setx(mousex);
				mca.loadButton.sety(mousey);
			}
			if (mca.moveselect==3){
				mca.leftButton.setx(mousex);
				mca.leftButton.sety(mousey);
			}
			if (mca.moveselect==4){
				mca.rightButton.setx(mousex);
				mca.rightButton.sety(mousey);
			}
			if (mca.moveselect==5){
				mca.playButton.setx(mousex);
				mca.playButton.sety(mousey);
			}
			
		}
		
		
		if (mca.playing)
		{
			return;
		}
	
		if (mca.running){
		if (mouse==1)
		{
		mca.PlacePiano2(mousex, mousey, NotePiano.note);		
	
		}
		else if (mouse==2)
		{
			System.out.println("Done right");

			
			mca.PlacePiano2(mousex, mousey, 0);		
		}
		
		else if (mouse==3){
			System.out.println("Selecting...");
			mca.selectx2=(int) Math.floor(mousex/32);	
			mca.selecty2=(int) Math.floor(mousey/32);
		}
		
		}
	
	}
		
	

	@Override
	public void mouseMoved(MouseEvent arg0) {
	}



	public void saveUrl(File filename, final String urlString)
	        throws MalformedURLException, IOException {
	    BufferedInputStream in = null;
	    FileOutputStream fout = null;
	    
	    
	    
	    
	    
	    try {
	    	in = new BufferedInputStream(new URL(urlString).openStream());
	        fout = new FileOutputStream(filename);

	        final byte data[] = new byte[1024];
	        int count;
	        while ((count = in.read(data, 0, 1024)) != -1) {
	            fout.write(data, 0, count);
	        }
	        
	        JOptionPane.showMessageDialog(null,
	        	    "Imported song.");
	    }
	    catch(FileNotFoundException e){
	    	JOptionPane.showMessageDialog(null,
	    		    "That song does not exist. Sorry.",
	    		    "Song NOT imported.",
	    		    JOptionPane.WARNING_MESSAGE);
	    }
	    finally {
	        if (in != null) {
	            in.close();
	        }
	        if (fout != null) {
	            fout.close();
	        }
	    }
	}

}
