package nathan;

import java.awt.*;
import java.awt.datatransfer.Clipboard;
import java.awt.datatransfer.DataFlavor;
import java.awt.datatransfer.StringSelection;
import java.awt.datatransfer.UnsupportedFlavorException;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;
import java.awt.image.BufferedImage;
import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.URI;
import java.net.URISyntaxException;
import java.net.URL;
import java.net.URLConnection;
import java.awt.Toolkit;
import javax.imageio.ImageIO;
import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.Clip;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.filechooser.FileNameExtensionFilter;


//public class MainClass extends Applet implements Runnable {
public class MainClass extends Canvas implements WindowListener, Runnable, KeyListener {
private static final long serialVersionUID = 1L;
	static NotePiano p;
	
	MouseListenerClass mousethingie;
	
	boolean previewing=false;
	
	Image dbImage;
	Graphics dbg;
	
	String[] themestrings = new String[30];

	BufferedImage previewimage=null;
	
	int daint=0;
	
	public double bpm = 100;
	
	Boolean testmode=false;
	Boolean themeshop=false;
	
	static Clip[] sounds = new Clip[57];
	//56
	
	int currentsound=0;
	
	//Robert's Code
	private static int xAd = (int)((Math.random()*(832-155))+1);
	private static int yAd = (int)((Math.random()*(576-180))+1);
	private static int xSpeed = (int)((Math.random()*9)-4);
	private static int ySpeed = (int)((Math.random()*9)-4);
	private static boolean pro = true;
	//End of Robert's Code

	public static int maxx=0;
	
	boolean movedabuttons;
	
	public boolean closesounds=false;
	
	public boolean beta=false;
	
	public int theme=1;
	
	static int world[][] = new int[401][57];
	public int offset;
	public int page=1;
	
	boolean selectmenu;
	
	public boolean options=false;
	
	int pianox=-1;
	
	
	static boolean canpress=true;
	boolean keyb=false;
	boolean spacebar=true;
	
	Thread thread = new Thread(this);
	
	//Thread soundthread = new Thread(new SoundPlayer());
	
	boolean line=true;
	
	boolean running=false;
	boolean playing=false;
	
	boolean title=true;
	
	static boolean wierd=false;
	
	public String custompath="";
	
	int moveselect=0;
	
	int oldoffset;
	
	boolean selecting;
	
	BufferedImage back;
	BufferedImage getcustomthemesbutton;
	BufferedImage backgroundimage = null;
	BufferedImage pianoimage;
	BufferedImage pianosharp;
	BufferedImage pianoflat;
	BufferedImage drum;
	BufferedImage bass;
	BufferedImage empty;
	BufferedImage basssharp;
	BufferedImage bassflat;
	BufferedImage back1;
	BufferedImage back2;
	BufferedImage TitleBackground;
	BufferedImage playbutton;
	BufferedImage optionsbutton;
	BufferedImage colorfullthumb;
	BufferedImage bpmimage;
	BufferedImage classicthumb;
	BufferedImage backgroundthumb;
	BufferedImage classicback1;
	BufferedImage classicback2;
	BufferedImage grayback1;
	BufferedImage grayback2;
	BufferedImage graythumb;
	BufferedImage customthumb;
	BufferedImage custom;
	BufferedImage loadbutton;
	BufferedImage spr_right_button;
	BufferedImage spr_left_button;
	BufferedImage spr_save_button;
	BufferedImage spr_load_button;
	BufferedImage movebuttonsbutton;
	BufferedImage importbutton;
	
	public boolean playOnPlace=true;
	
	MouseListenerClass mlc;
	
	
	boolean dopreload=false;
	
	Color happywhite;

	public int selectx1;
	public int selectx2;
	public int selecty1;
	public int selecty2;
	
	
	static String[] piano = new String[14];
	static String[] pianosharp_a = new String[14];
	static String[] pianoflat_a = new String[14];
	
	BufferedImage play_button;
	BufferedImage stop_button;
	
	ze_buttons playButton;
	ze_buttons leftButton;
	ze_buttons rightButton,saveButton,loadButton;
	
	
	//public Clip[] clips = new Clip[351];
	public Clip[] clips = new Clip[351];
	public int currentclip=0;
	
	public static void main(String[] args)
	{
		JFrame frame = new JFrame("Growtopia Music Simulator");
		MainClass a = new MainClass(frame);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	    frame.pack();
	    frame.setSize(832,576);
	    frame.setResizable(false);
	    frame.setLocationRelativeTo(null);
	    
	    frame.setVisible(true);
	    //MainClass a = new MainClass(frame); 
	    
	    frame.add(a);
	    //Robert's Code
		while(xSpeed == 0 || ySpeed == 0)
		{
			xSpeed = (int)((Math.random()*9)-4);
			ySpeed = (int)((Math.random()*9)-4);
		}
		//End of Robert's Code
	    
	}


	public MainClass(JFrame daframe){
	//public MainClass(){
		
		
		try {
			bpmimage = ImageIO.read(getClass().getResourceAsStream("bpm.png"));
			backgroundimage = ImageIO.read(getClass().getResourceAsStream("background.png"));
			back1 = ImageIO.read(getClass().getResourceAsStream("back1.png"));
			back2 = ImageIO.read(getClass().getResourceAsStream("back2.png"));
			pianoimage = ImageIO.read(getClass().getResourceAsStream("PianoNote.png"));
			pianosharp = ImageIO.read(getClass().getResourceAsStream("Piano_sharp.png"));
			pianoflat = ImageIO.read(getClass().getResourceAsStream("Piano_flat.png"));
			drum = ImageIO.read(getClass().getResourceAsStream("Drum.png"));
			bass = ImageIO.read(getClass().getResourceAsStream("Bass.png"));
			empty = ImageIO.read(getClass().getResourceAsStream("Piano_blank.png"));
			basssharp = ImageIO.read(getClass().getResourceAsStream("Sharp_Bass.png"));
			bassflat = ImageIO.read(getClass().getResourceAsStream("Flat_Bass.png"));
			TitleBackground = ImageIO.read(getClass().getResourceAsStream("Title.png"));
			playbutton = ImageIO.read(getClass().getResourceAsStream("but1.png"));
			loadbutton = ImageIO.read(getClass().getResourceAsStream("but2.png"));
			optionsbutton = ImageIO.read(getClass().getResourceAsStream("but3.png"));
			classicthumb = ImageIO.read(getClass().getResourceAsStream("classicthumb.png"));
			colorfullthumb = ImageIO.read(getClass().getResourceAsStream("colorfullthumb.png"));
			backgroundthumb = ImageIO.read(getClass().getResourceAsStream("backgroundthumb.png"));
			classicback1 = ImageIO.read(getClass().getResourceAsStream("classicback1.png"));
			classicback2 = ImageIO.read(getClass().getResourceAsStream("classicback2.png"));
			grayback1 = ImageIO.read(getClass().getResourceAsStream("grayback1.png"));
			grayback2 = ImageIO.read(getClass().getResourceAsStream("grayback2.png"));
			graythumb = ImageIO.read(getClass().getResourceAsStream("graythumb.png"));
			customthumb = ImageIO.read(getClass().getResourceAsStream("custom.png"));
			importbutton = ImageIO.read(getClass().getResourceAsStream("Import.png"));
			
			back = ImageIO.read(getClass().getResourceAsStream("back.png"));
			
			spr_left_button = ImageIO.read(getClass().getResourceAsStream("left_button.png"));
			spr_right_button = ImageIO.read(getClass().getResourceAsStream("right_button.png"));
			spr_save_button = ImageIO.read(getClass().getResourceAsStream("save.png"));
			spr_load_button = ImageIO.read(getClass().getResourceAsStream("load_button.png"));
			movebuttonsbutton = ImageIO.read(getClass().getResourceAsStream("but5.png"));
			getcustomthemesbutton = ImageIO.read(getClass().getResourceAsStream("getcustomthemes.png"));
			
			//bassflat = ImageIO.read(getClass().getResourceAsStream("Flat_Bass.png"));
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		//Robert's Code
		try {		
			play_button = ImageIO.read(getClass().getResourceAsStream("Play_Button.png"));
			stop_button = ImageIO.read(getClass().getResourceAsStream("Stop_Button.png"));
		} catch (IOException a) {
		}
		
		daframe.setIconImage(pianoimage);
		
		//g.drawImage(spr_save_button,60,460,this);
		//g.drawImage(spr_load_button,60,498,this);
		//g.drawImage(spr_left_button,230,480,this);
		//g.drawImage(spr_right_button,284,480,this);
		
		playButton = new ze_buttons(380,470,128,59,play_button,stop_button,this);
		saveButton = new ze_buttons(60,460,32,32,spr_save_button,spr_save_button,this);
		loadButton = new ze_buttons(60,498,32,32,spr_load_button,spr_load_button,this);
		leftButton = new ze_buttons(230,480,32,32,spr_left_button,spr_left_button,this);
		rightButton = new ze_buttons(284,480,32,32,spr_right_button,spr_right_button,this);
		
		
		piano[0]="piano_high_b.wav";
		piano[1]="piano_high_a.wav";	
		piano[2]="piano_high_g.wav";
		piano[3]="piano_high_f.wav";
		piano[4]="piano_high_e.wav";	
		piano[5]="piano_high_d.wav";
		piano[6]="piano_c.wav";
		piano[7]="piano_b.wav";
		piano[8]="piano_a.wav";	
		piano[9]="piano_g.wav";	
		piano[10]="piano_f.wav";
		piano[11]="piano_e.wav";
		piano[12]="piano_low_d.wav";	
		piano[13]="piano_low_c.wav";	

		pianosharp_a[0]="piano_high_c.wav";
		pianosharp_a[1]="piano_high_a_sharp.wav";	
		pianosharp_a[2]="piano_high_g_sharp_a_flat.wav";	
		pianosharp_a[3]="piano_high_f_sharp.wav";	
		pianosharp_a[4]="piano_high_f.wav";	
		pianosharp_a[5]="piano_d_sharp_e_flat.wav";	
		pianosharp_a[6]="piano_c_sharp_d_flat.wav";	
		pianosharp_a[7]="piano_c.wav";	
		pianosharp_a[8]="piano_a_sharp_b_flat.wav";	
		pianosharp_a[9]="piano_g_sharp_a_flat.wav";	
		pianosharp_a[10]="piano_f_sharp_g_flat.wav";	
		pianosharp_a[11]="piano_f.wav";	
		pianosharp_a[12]="piano_low_d_sharp_e_flat.wav";	
		pianosharp_a[13]="piano_low_c_sharp_or_d_flat.wav";	

		pianoflat_a[0]="piano_high_a_sharp.wav";
		pianoflat_a[1]="piano_high_g_sharp_a_flat.wav";	
		pianoflat_a[2]="piano_high_f_sharp_g_flat.wav";	
		pianoflat_a[3]="piano_high_e.wav";	
		pianoflat_a[4]="piano_d_sharp_e_flat.wav";	
		pianoflat_a[5]="piano_c_sharp_d_flat.wav";	
		pianoflat_a[6]="piano_b.wav";	
		pianoflat_a[7]="piano_a_sharp_b_flat.wav";	
		pianoflat_a[8]="piano_g_sharp_a_flat.wav";	
		pianoflat_a[9]="piano_f_sharp_g_flat.wav";	
		pianoflat_a[10]="piano_e.wav";	
		pianoflat_a[11]="piano_low_d_sharp_e_flat.wav";	
		pianoflat_a[12]="piano_low_c_sharp_or_d_flat.wav";	
		pianoflat_a[13]="piano_c_flat_which_is_b.wav";
		
		
		
		URL url;
		
		int version=189;
		
		try {
			url = new URL("http://mylegguy.x10.mx/GMS.mylegguy");

        URLConnection con = url.openConnection();
        InputStream is =con.getInputStream();

        BufferedReader br = new BufferedReader(new InputStreamReader(is));

        String line = null;


        line = br.readLine();

        	//System.out.println(line);
        
        	if (Integer.parseInt(line)!=version){
        		line = br.readLine();
        		JOptionPane.showMessageDialog(null, "Update Avalible! "+line, "Update avalible!", JOptionPane.INFORMATION_MESSAGE);
        		

        		Object[] optionsa = {"Yes!",
                "Copy the url to my clipboard.", "No, thanks."};
int n = JOptionPane.showOptionDialog(null,
"Would you like to open the forum post now?",
"A question",
JOptionPane.YES_NO_OPTION,
JOptionPane.QUESTION_MESSAGE,
null,     //do not use a custom Icon
optionsa,  //the titles of buttons
optionsa[2]); //default button title
        		
System.out.println(n);

if (n==0){

                if (Desktop.isDesktopSupported()) {
                    // Windows
                    try {
						Desktop.getDesktop().browse(new URI("http://www.rtsoft.com/forums/showthread.php?226847-Release-Growtopia-Music-Simulator"));
					} catch (URISyntaxException e) {
						JOptionPane.showMessageDialog(null, "Could not open the url.");
						e.printStackTrace();
					}
                } else {
                	JOptionPane.showMessageDialog(null, "Desktop.isDesktopSupported returned false. You won't be able to open the url directly from here. Sorry.");
                }
        		
        	
        	}
                

if (n==1){
   
    Toolkit defaultToolkit = Toolkit.getDefaultToolkit();
	
	Clipboard clipboard = defaultToolkit.getSystemClipboard();

    clipboard.setContents(new StringSelection("http://www.rtsoft.com/forums/showthread.php?226847-Release-Growtopia-Music-Simulator"), null);

    Object text = null;
	try {
		text = clipboard.getData(DataFlavor.stringFlavor);
	} catch (UnsupportedFlavorException e) {
		JOptionPane.showMessageDialog(null, "Could not get the keyboard's current contence. Oh well.");
		e.printStackTrace();
	}
    
	JOptionPane.showMessageDialog(null, "Done. Your clipboard is now: " + (String) text);
}

                
                
        	}
        	
		
		} catch (IOException e) {
		
			System.out.println("Could not check for updates...");
			e.printStackTrace();
			
		}
		
		
		
		
		InputStream is_l = null;
	      int i_l;
			      try{
			    	  is_l = new FileInputStream("Options.mylegguy");

				         //System.out.println("Characters printed:");
				         
				         // reads till the end of the stream
				         //while((i=is.read())!=-1)
				         //System.out.println("Rya:"+rya);
			    	  String tempstring = "";
				         
				         i_l=is_l.read();				         
				         theme = Character.getNumericValue(i_l);
				         i_l=is_l.read();
				         if (Character.getNumericValue(i_l)!=1){playOnPlace=false;}
				         i_l=is_l.read();
				         if (Character.getNumericValue(i_l)!=1){dopreload=false;}
				         i_l=is_l.read();
				         if (Character.getNumericValue(i_l)!=1){line=false;}
				         i_l=is_l.read();
				         if (Character.getNumericValue(i_l)==1){closesounds=true;}
				         
				         i_l=is_l.read();
				         tempstring=tempstring+Character.getNumericValue(i_l);
				         i_l=is_l.read();
				         tempstring=tempstring+Character.getNumericValue(i_l);
				         i_l=is_l.read();
				         tempstring=tempstring+Character.getNumericValue(i_l);
				         
				         try{
				         bpm = Integer.parseInt(tempstring);
				         }
				         catch(NumberFormatException nfe){
				        	 JOptionPane.showMessageDialog(null,
				        			    "The bpm could not be loaded. When I say that, I mean whatever was loaded couldn't be converted to a number. So, uh... It probrablly loaded invalid numbers... Please delete your options file. I could do it, but I don't honestly expect anybody to see this warning, so I'll just make it give you text instructions...",
				        			    "bad stuff is happening!",
				        			    JOptionPane.WARNING_MESSAGE);
				         }
				         
				         tempstring="";
				         for(int i=0; i<3; i++){
					        i_l=is_l.read();				         
					        tempstring = tempstring+Character.toString((char)i_l);
				         }
				         saveButton.setx(Integer.parseInt(tempstring));
				         System.out.println(tempstring);
				         tempstring="";
				         for(int i=0; i<3; i++){
					        i_l=is_l.read();				         
					        tempstring = tempstring+Character.toString((char)i_l);
				         }
				         saveButton.sety(Integer.parseInt(tempstring));
				         System.out.println(tempstring);
				         tempstring="";
				         for(int i=0; i<3; i++){
					        i_l=is_l.read();				         
					        tempstring = tempstring+Character.toString((char)i_l);
				         }
				         loadButton.setx(Integer.parseInt(tempstring));
				         System.out.println(tempstring);
				         tempstring="";
				         for(int i=0; i<3; i++){
					        i_l=is_l.read();				         
					        tempstring = tempstring+Character.toString((char)i_l);
				         }
				         loadButton.sety(Integer.parseInt(tempstring));
				         System.out.println(tempstring);
				         tempstring="";
				         for(int i=0; i<3; i++){
					        i_l=is_l.read();				         
					        tempstring = tempstring+Character.toString((char)i_l);
				         }
				         leftButton.setx(Integer.parseInt(tempstring));
				         System.out.println(tempstring);
				         tempstring="";
				         for(int i=0; i<3; i++){
					        i_l=is_l.read();				         
					        tempstring = tempstring+Character.toString((char)i_l);
				         }
				         leftButton.sety(Integer.parseInt(tempstring));
				         System.out.println(tempstring);
				         tempstring="";
				         for(int i=0; i<3; i++){
					        i_l=is_l.read();				         
					        tempstring = tempstring+Character.toString((char)i_l);
				         }
				         rightButton.setx(Integer.parseInt(tempstring));
				         System.out.println(tempstring);
				         tempstring="";
				         for(int i=0; i<3; i++){
					        i_l=is_l.read();				         
					        tempstring = tempstring+Character.toString((char)i_l);
				         }
				         rightButton.sety(Integer.parseInt(tempstring));
				         System.out.println(tempstring);
				         tempstring="";
				         for(int i=0; i<3; i++){
					        i_l=is_l.read();				         
					        tempstring = tempstring+Character.toString((char)i_l);
				         }
				         playButton.setx(Integer.parseInt(tempstring));
				         System.out.println(tempstring);
				         tempstring="";
				         for(int i=0; i<3; i++){
					        i_l=is_l.read();				         
					       System.out.println(i_l); 
					        tempstring = tempstring+Character.toString((char)i_l);
				         }
				         System.out.println(tempstring);
				         playButton.sety(Integer.parseInt(tempstring));
				         
				         System.out.println("Da end...");
				         
				         if (theme==5){
				         i_l=is_l.read();
				         String temp = ""+Character.getNumericValue(i_l);
				         i_l=is_l.read();
				         temp=temp+Character.getNumericValue(i_l);
				         
				         for(int i=1; i<Integer.parseInt(temp)+1; i++){
				             // System.out.println("Count is: " + i);
				              i_l=is_l.read();
				              custompath=custompath+String.valueOf(Character.toChars(i_l));
				              System.out.println(custompath);
				         }
				         
				         custom = ImageIO.read(new File(custompath));
				         
				         
				         
				         }
				         System.out.println("Achived new");
				      }catch(Exception el){
				         System.out.println(el);
				         // if any I/O error occurs
				    	  System.out.println("It wasn't found... the options file, that is");
				    	 // e.printStackTrace();
				    	  File file = new File("Options.mylegguy");
					    	 file.delete();
								FileWriter fw = null;
								try {
									fw = new FileWriter(file.getAbsoluteFile());
								} catch (IOException e2) {
							
									e2.printStackTrace();
								}
								BufferedWriter bw = new BufferedWriter(fw);
								try {
									//bw.write("101013804706046060498230480284480");
									//bw.write("1010380470060460060498230480284480");
									
									bw.write("11010100060460060498230480284480380470");
									
								} catch (IOException e2) {
							
									e2.printStackTrace();
								}
								try {
									bw.close();
								} catch (IOException e2) {
						
									e2.printStackTrace();
								}
					    	 try {
								file.createNewFile();
							} catch (IOException e1) {
	
								e1.printStackTrace();
							}

						
				      }finally{
				         
				         // releases system resources associated with this stream
				         if(is_l!=null)
							try {
								is_l.close();
							} catch (IOException ea) {
						
								ea.printStackTrace();
							}
				      }
		
		
		happywhite = new Color(255, 255, 255, 200);		
		if (dopreload){preload();}
		 start();
	}


	
	
	public void start(){
		//p = new NotePiano(this);
		
		//mousethingie = new MouseListenerClass();
		

		mlc = new MouseListenerClass(this,playButton);
		
		this.addMouseListener(mlc);
		this.addMouseWheelListener(mlc);
		this.addMouseMotionListener(mlc);
		
		System.out.println("Got to start");
		
	thread.start();
	}
	
	
	
	public void destory(){running=false;playing=false;}
	public void stop(){running=false;playing=false;}
	public void run(){

		System.out.println("Got to run..");
		
		
		while (testmode){
			repaint();
			try
			{
				Thread.sleep(20);
			}
			catch(InterruptedException e){	
				System.out.print(e);
			}
		}
		
		while (movedabuttons){
			repaint();
			
			
			
			try
			{
				Thread.sleep(20);
			}
			catch(InterruptedException e){	
				System.out.print("Error in MOVEDABUTTONS. NO COULD SLEP!!!!");
			}
			
		}
		
		while (options){
			
			repaint();
			
			
			
			try
			{
				Thread.sleep(20);
			}
			catch(InterruptedException e){	
				System.out.print("Error.");
			}
		}
		repaint();
		
		System.out.println("Before title...");
		
		while (title){
			repaint();
			
			//System.out.println("A");
			
			if (gotoplay){
				gotoplay=false;
				title=false;
				running=true;
				p = new NotePiano(this);
				p.x=144;
				p.y=470;
				this.addKeyListener(this);
			}
			
			try
			{
				Thread.sleep(20);
			}
			catch(InterruptedException e){	
				System.out.print("Error.");
			}
			
		}
		
		System.out.println("Down here...");
		
		while (running){
	repaint();
			
			if (p==null){p = new NotePiano(this);}
			
			p.update(this);
			
			canpress=true;
			
			try
			{
				Thread.sleep(20);
			}
			catch(InterruptedException e){	
				System.out.print("Error.");
			}
		}
		
		repaint();
		
		while (playing){
			if (p==null){p = new NotePiano(this);}
			p.update(this);
			

			
			canpress=true;

			
			if (pianox>offset+24){
				offset=pianox; page+=1;
				if (closesounds==true){
			System.out.println("Closing " + currentclip + " sounds...");
			System.out.println("Currentclip: "+currentclip);
			
		         for(int i=0; i<currentclip-1; i++){
		              clips[i].close();
		              System.out.println("Closed sound"+i+" .");
		         }
		       currentclip=0;
			}
			
			}
			
			pianox+=1;
			if (pianox>maxx){
				pianox=0;
				offset=0;
				page=1;
				if (closesounds==true){
			         for(int i=0; i<currentclip-1; i++){
			              clips[i].close();
			              System.out.println("Closed sound"+i+" .");
			         }
			       currentclip=0;
				}
			}

	                	for(int i=0; i<15; i++){
	                		if (world[pianox][i]==1){
	                			PlaySound(piano[i]);
	                			
	                			
	                		}
	                		if (world[pianox][i]==2){
	                			PlaySound(pianosharp_a[i]);
	                			
	                		}
	                		if (world[pianox][i]==3){
	                			
	                			PlaySound(pianoflat_a[i]);
	                		}
	                		
	                		if (world[pianox][i]==4){
		                		System.out.println("Played bass");
	                			if (i==0){
	                				PlaySound("bass_high_b.wav");
	                			}
	                			if (i==1){
	                				PlaySound("bass_a.wav");	
	                			}
	                			if (i==2){
	                				PlaySound("bass_g.wav");
	                			}
	                			if (i==3){
	                				PlaySound("bass_f.wav");
	                			}
	                			if (i==4){
	                				PlaySound("bass_e.wav");	
	                			}
	                			if (i==5){
	                				PlaySound("bass_d.wav");
	                			}
	                			if (i==6){
	                				PlaySound("bass_c.wav");	
	                			}
	                			if (i==7){
	                				PlaySound("bass_low_b.wav");
	                			}
	                			if (i==8){
	                				PlaySound("bass_low_a.wav");	
	                			}
	                			if (i==9){
	                				PlaySound("bass_low_g.wav");	

	                			}
	                			if (i==10){
	                				PlaySound("bass_low_f.wav");

	                			}
	                			if (i==11){
	                				PlaySound("bass_low_e.wav");

	                			}
	                			if (i==12){
	                				PlaySound("bass_low_d.wav");	

	                			}
	                			if (i==13){
	                				PlaySound("bass_low_c.wav");	

	                			}
	                			
	                		}
	                		if (world[pianox][i]==5){
	                			if (i==0){
	                				PlaySound("bass_high_c.wav");
	                			}
	                			if (i==1){
	                				PlaySound("bass_b_flat_a_sharp.wav");	
	                			}
	                			if (i==2){
	                				PlaySound("bass_a_flat_g_sharp.wav");	
	                			}
	                			if (i==3){
	                				PlaySound("bass_g_flat_f_sharp.wav");	
	                			}
	                			if (i==4){
	                				PlaySound("bass_f.wav");	
	                			}
	                			if (i==5){
	                				PlaySound("bass_e_flat_d_sharp.wav");	
	                			}
	                			if (i==6){
	                				PlaySound("bass_d_flat_c_sharp.wav");	
	                			}
	                			if (i==7){
	                				PlaySound("bass_c.wav");	
	                			}
	                			if (i==8){
	                				PlaySound("bass_low_b_flat_a_sharp.wav");	
	                			}
	                			if (i==9){
	                				PlaySound("bass_low_a_flat_g_sharp.wav");	
	                			}
	                			if (i==10){
	                				PlaySound("bass_low_g_flat_f_sharp.wav");	
	                			}
	                			if (i==11){
	                				PlaySound("bass_low_f.wav");	
	                			}
	                			if (i==12){
	                				PlaySound("bass_low_e_flat_d_sharp.wav");	
	                			}
	                			if (i==13){
	                				PlaySound("bass_low_d_flat_c_sharp.wav");	
	                			}
	                			
	                		}
	                		if (world[pianox][i]==6){
	                			if (i==0){
	                				PlaySound("bass_b_flat_a_sharp.wav");
	                			}
	                			if (i==1){
	                				PlaySound("bass_a_flat_g_sharp.wav");	
	                			}
	                			if (i==2){
	                				PlaySound("bass_g_flat_f_sharp.wav");	
	                			}
	                			if (i==3){
	                				PlaySound("bass_e.wav");	
	                			}
	                			if (i==4){
	                				PlaySound("bass_e_flat_d_sharp.wav");	
	                			}
	                			if (i==5){
	                				PlaySound("bass_d_flat_c_sharp.wav");	
	                			}
	                			if (i==6){
	                				PlaySound("bass_b.wav");	
	                			}
	                			if (i==7){
	                				PlaySound("bass_b_flat_a_sharp.wav");	
	                			}
	                			if (i==8){
	                				PlaySound("bass_low_a_flat_g_sharp.wav");	
	                			}
	                			if (i==9){
	                				PlaySound("bass_low_g_flat_f_sharp.wav");	
	                			}
	                			if (i==10){
	                				PlaySound("bass_low_e.wav");	
	                			}
	                			if (i==11){
	                				PlaySound("bass_low_e_flat_d_sharp.wav");	
	                			}
	                			if (i==12){
	                				PlaySound("bass_low_d_flat_c_sharp.wav");	
	                			}
	                			if (i==13){
	                				PlaySound("bass_low_b.wav");	
	                			}
	                			
	                		}
	                		
	                		if (world[pianox][i]==7){
	                			if (i==0){
	                				PlaySound("drum_0.wav");
	                			}
	                			if (i==1){
	                				PlaySound("drum_1.wav");	
	                			}
	                			if (i==2){
	                				PlaySound("drum_2.wav");	
	                			}
	                			if (i==3){
	                				PlaySound("drum_3.wav");	
	                			}
	                			if (i==4){
	                				PlaySound("drum_4.wav");	
	                			}
	                			if (i==5){
	                				PlaySound("drum_5.wav");	
	                			}
	                			if (i==6){
	                				PlaySound("drum_6.wav");	
	                			}
	                			if (i==7){
	                				PlaySound("drum_0.wav");	
	                			}
	                			if (i==8){
	                				PlaySound("drum_1.wav");	
	                			}
	                			if (i==9){
	                				PlaySound("drum_2.wav");	
	                			}
	                			if (i==10){
	                				PlaySound("drum_3.wav");	
	                			}
	                			if (i==11){
	                				PlaySound("drum_4.wav");	
	                			}
	                			if (i==12){
	                				PlaySound("drum_5.wav");	
	                			}
	                			if (i==13){
	                				PlaySound("drum_6.wav");	
	                			}
	                			
	                		}
	                	
	           }
	       
	                	if (line){repaint();}
	                	
			try
			{
				//Thread.sleep(150*(1/(bpm/100)));
				Thread.sleep((int) (150.0*(1.0/(bpm/100.0))));
			}
			catch(InterruptedException e){	
				System.out.print("Error.");
			}
		}
		
		while (themeshop)
		{
			repaint();
			
			
			try
			{
				Thread.sleep(20);
			}
			catch(InterruptedException e){	
				System.out.print("Error.");
			}
		}
		
		while (previewing){
			//previewimage
			repaint();
			
			try
			{
				Thread.sleep(20);
			}
			catch(InterruptedException e){	
				System.out.print("Error.");
			}
		}
		
		
		//System.out.println(playing);
		//System.out.println(running);
		run();

	}
	
	public void update(Graphics g){
		
		//if (true){return;}
		
		dbImage = createImage(getWidth(),getHeight());
		
		dbg = dbImage.getGraphics();
		paint(dbg);
		g.drawImage(dbImage,0,0,this);
		
		/*
		//Robert's Code
		xAd += xSpeed;
		yAd += ySpeed;
		if(xAd >= (832-155) || xAd <= 0)
			xSpeed *= -1;
		if(yAd >= (576-180) || yAd <= 0)
			ySpeed *= -1;
		//End of Robert's Code
		*/
	}
	

	
	
	
	public void paint(Graphics g){
		
		//System.out.println("Paint...");
		
		if (previewing){
			g.drawImage(previewimage,0,0,this);
			g.drawImage(back,32,32,this);
		}
		
		if (themeshop){
			g.drawImage(back,0,0,this);
			for(int i=0; i<daint/2; i++){
				g.drawString(themestrings[(i*2)], 200, (i*17)+17);
			}
		}

		if (testmode){
			g.drawString("Hello.", 32, 32);
		}
		
		if (movedabuttons){
			
			if (theme==1){
				g.drawImage(back2,0,0,this);
				}
				if (theme==2){
				g.drawImage(classicback2,0,0,this);
				}
				if (theme==3){
				g.drawImage(backgroundimage,0,0,this);
				g.drawString("Current page:"+page+"/16", 460, 500);
				}
				if (theme==4){
				g.drawImage(grayback2,0,0,this);
				}
				if (theme==5){
				g.drawImage(custom,0,0,this);
				}
			
			
				g.drawImage(saveButton.getimage(),saveButton.getx(),saveButton.gety(),this);
				g.drawImage(loadButton.getimage(),loadButton.getx(),loadButton.gety(),this);
				g.drawImage(leftButton.getimage(),leftButton.getx(),leftButton.gety(),this);
				g.drawImage(rightButton.getimage(),rightButton.getx(),rightButton.gety(),this);
				g.drawImage(playButton.getimage(), playButton.getx(), playButton.gety(), this);
				
				//System.out.println(moveselect);
				g.drawImage(back,32,32,this);
			
			
			
		}
		
		if (options){
			g.drawString("Options", 360, 32);
			g.drawString("Select a theme", 344, 56);
			g.drawImage(colorfullthumb,32,36,this);
			g.drawString("Colorfull", 118, 56);
			g.drawImage(classicthumb,280,186,this);
			g.drawString("Classic - Mouse", 330, 170);
			g.drawImage(backgroundthumb,528,336,this);
			g.drawString("Classic - Keyboard", 578, 316);
			g.drawImage(graythumb,32,300,this);
			g.drawString("Gray", 130, 300);
			//g.drawString("Load sounds on launch - ", 600, 48);
			//if (dopreload){g.setColor(Color.GREEN);} else {g.setColor(Color.RED);}
			//g.fillRect(750, 32, 32, 32);
			if (playOnPlace){g.setColor(Color.GREEN);} else {g.setColor(Color.RED);}
			g.fillRect(750, 80, 32, 32);
			g.setColor(Color.BLACK);
			g.drawString("Play note on place - ", 632, 96);
			
			if (line){g.setColor(Color.GREEN);} else {g.setColor(Color.RED);}
			g.fillRect(750, 128, 32, 32);
			g.setColor(Color.BLACK);
			g.drawString("That line thingie - ", 632, 144);
			
			if (closesounds){g.setColor(Color.GREEN);} else {g.setColor(Color.RED);}
			g.fillRect(532, 128, 32, 32);
			g.setColor(Color.BLACK);
			g.drawString("Close sounds (Crash fixer) - ", 370, 144);
			
			g.drawImage(customthumb,600,170,this);
			g.drawString("Custom Theme", 600, 267);
			
			
			g.drawString("Current BPM - " + (int)(bpm), 630, 50);
			g.drawImage(bpmimage,750,32,this);
			
			
		}
		
		if (title){
			g.drawImage(TitleBackground,0,0,this);
			g.drawImage(playbutton,300,300,this);
			g.drawImage(getcustomthemesbutton,26,300,this);
			g.drawImage(importbutton,574,400,this);
			g.drawImage(loadbutton,574,300,this);
			g.drawImage(movebuttonsbutton,26,418,this);
			g.drawImage(optionsbutton,300,418,this);
			g.drawString("Programmer - MyLegGuy", 560, 500);
			g.drawString("Matched sounds to notes - HonestyCow", 560, 516);
			g.drawString("Theme Creator && lesser-sub-programmer - SumRndmDde", 460, 530);
			g.drawString("y3ll0 - Nothing", 360, 538);
			g.drawString("V1.89", 16, 530);
		}
		
		//System.out.println("a");
		
		if (playing){
			
			if (theme==1){
			g.drawImage(back2,0,0,this);
			}
			if (theme==2){
			g.drawImage(classicback2,0,0,this);
			}
			if (theme==3){
			g.drawImage(backgroundimage,0,0,this);
			g.drawString("Current page:"+page+"/16", 460, 500);
			}
			if (theme==4){
			g.drawImage(grayback2,0,0,this);
			}
			if (theme==5){
			g.drawImage(custom,0,0,this);
			}
			g.drawString("Current page:"+page+"/16", 230, 538);
			g.drawImage(saveButton.getimage(),saveButton.getx(),saveButton.gety(),this);
			g.drawImage(loadButton.getimage(),loadButton.getx(),loadButton.gety(),this);
			g.drawImage(leftButton.getimage(),leftButton.getx(),leftButton.gety(),this);
			g.drawImage(rightButton.getimage(),rightButton.getx(),rightButton.gety(),this);
	
			//Robert's Code Here
			g.drawImage(playButton.getimage2(), playButton.getx(), playButton.gety(), this);
			
		}
		
		if (running){
		
			
			
			
			if (theme==1){
			g.drawImage(back1,0,0,this);
			}
			if (theme==2){
			g.drawImage(classicback1,0,0,this);
			}
			if (theme==3){
			g.drawImage(backgroundimage,0,0,this);
			g.drawString("Current page:"+page+"/16", 460, 500);
			g.drawString("Programmed by MyLegGuy", 208, 495);
			g.drawString("Matched sounds to notes: HonestyCow", 208, 510);
			g.drawString("Mouse Controls: Click to place note. Scroll to change note. Right click to remove note.", 170, 532);
			g.drawString("Permission was givin for the sounds.", 280, 543);
			}
			if (theme==4){
			g.drawImage(grayback1,0,0,this);
			}
			
			if (theme!=3){
				
				g.drawString("Current page:"+page+"/16", 230, 538);
				
			}
			if (theme==5){
			g.drawImage(custom,0,0,this);
			}
			
			if (selectmenu && theme!=3){
				g.setColor(Color.WHITE);
				g.fillRect(0, 448, 832, 128);
				g.setColor(Color.BLACK);
				g.drawString("X - Delete selected", 100, 500);
			}
			
			
			if (selecting | selectmenu){
				Graphics2D g2 = (Graphics2D) g;
				 g2.setStroke(new BasicStroke(10));
				g.setColor(Color.GREEN);
				if (selectx2>selectx1 && selecty1>selecty2){g.drawRect(selectx1*32, selecty2*32, (selectx2-selectx1)*32, (selecty1-selecty2)*32);}
				else if (selectx2>selectx1 && selecty1<selecty2){g.drawRect(selectx1*32, selecty1*32, (selectx2-selectx1)*32, (selecty2-selecty1)*32);}
				else if (selectx2<selectx1 && selecty1>selecty2){g.drawRect(selectx2*32, selecty2*32, (selectx1-selectx2)*32, (selecty1-selecty2)*32);}
				else if (selectx2<selectx1 && selecty1<selecty2){g.drawRect(selectx2*32, selecty1*32, (selectx1-selectx2)*32, (selecty2-selecty1)*32);}
				
			}
			 
			
			g.drawImage(saveButton.getimage(),saveButton.getx(),saveButton.gety(),this);
			g.drawImage(loadButton.getimage(),loadButton.getx(),loadButton.gety(),this);
			g.drawImage(leftButton.getimage(),leftButton.getx(),leftButton.gety(),this);
			g.drawImage(rightButton.getimage(),rightButton.getx(),rightButton.gety(),this);
			
			
			
			//Robert's Code Here
			g.drawImage(playButton.getimage(), playButton.getx(), playButton.gety(), this);
			
		}
		
		if (running | playing){
		
		for(int i=0; i<15; i++){
            for(int i2=0; i2<25; i2++){
            	if (world[i2+offset][i]==1){
                	g.drawImage(pianoimage,i2*32,i*32,this);
                }
                if (world[i2+offset][i]==2){
                	g.drawImage(pianosharp,i2*32,i*32,this);
                }
                if (world[i2+offset][i]==3){
                	g.drawImage(pianoflat,i2*32,i*32,this);
                }
                if (world[i2+offset][i]==4){
                	g.drawImage(bass,i2*32,i*32,this);
                }
                if (world[i2+offset][i]==5){
                	g.drawImage(basssharp,i2*32,i*32,this);
                }
                if (world[i2+offset][i]==6){
                	g.drawImage(bassflat,i2*32,i*32,this);
                }
                if (world[i2+offset][i]==7){
                	g.drawImage(drum,i2*32,i*32,this);
                }
                if (world[i2+offset][i]==8){
                	g.drawImage(empty,i2*32,i*32,this);
                }
           }
       }

		}
		
		
		if (playing && line){
			System.out.println("Line enabled. Pianox:"+pianox);
			g.setColor(happywhite);
			g.fillRect(((pianox-offset)*32), 0, 32, 448);
			g.setColor(Color.BLACK);
			
		}
		
		//Robert's Code
		if(!pro && !playing && !options && !title)
		{
			g.setColor(Color.BLACK);
			g.fillRect(xAd, yAd, 150, 150);
			g.setColor(Color.WHITE);
			//g.drawString("BUY PRO VERSION!", xAd + 18, yAd + 20);
			g.drawString("This is the beta.", xAd + 18, yAd + 20);
			g.drawString("Report bugs to MyLegGuy", xAd + 5, yAd + 36);
			//g.drawString("ONLY 10 WORLD LOCKS!", xAd + 5, yAd + 60);
			//g.drawString(" - Get more pages!", xAd + 10, yAd + 100);
			//g.drawString(" - Remove this weird ad.", xAd + 10, yAd + 120);
			//g.drawString(" - Brag to your friends!", xAd + 10, yAd + 140);
		}
		//End of Robert's Code

		if (p!=null)
		{
			if (!selectmenu){
			p.paint(g,this);
			g.setColor(Color.RED);
			g.drawRect(p.x, p.y, 32, 32);	
			}
		}
		

	}
	
	public void PlacePiano(NotePiano thingie, int noteValue) {
		
		if (thingie.x/32+offset>25){

			return;
			}
		if (thingie.y/32>14){
			return;
			}
		
		MainClass.world[thingie.x/32+offset][thingie.y/32]=noteValue;
		
		if (playOnPlace){
			
			playnote(thingie.x/32+offset, thingie.y/32);
			
			}
	}
	

	
	public void PlacePiano2(int mx, int my, int noteValue) {
	//	System.out.println("a");
		int tempmx = (int) Math.floor(mx/32);
		int tempmy = (int) Math.floor(my/32);
		
		if (tempmx>24){
			return;
			}
		if (tempmy>13){
			return;
			}
		if (tempmx<0){
			tempmx=0;
			}
		if (tempmy<0){
			tempmy=0;
			}
		if (tempmx+offset>maxx){
		maxx=tempmx+offset;	
		}
		
		if (world[tempmx+offset][tempmy]==noteValue){return;}
		
		MainClass.world[tempmx+offset][tempmy]=noteValue;
	
		if (playOnPlace){
			
			playnote(tempmx+offset, tempmy);
			
			}
		
		//	System.out.println(tempmx);
	//	System.out.println(tempmy);
		
		
		
	}
	
	


	
	void PlaySound(String filename) {
	    try (InputStream in = getClass().getResourceAsStream(filename)) {
	    	InputStream bufferedIn = new BufferedInputStream(in);
	        try (AudioInputStream audioIn = AudioSystem.getAudioInputStream(bufferedIn)) {
	        bufferedIn=null;
	        if (closesounds==true){	
	        clips[currentclip] = AudioSystem.getClip();
	        	clips[currentclip].open(audioIn);
	        	clips[currentclip].start();
	        	currentclip+=1;
	        
	    		//(new Thread(new CloseSoundThread(clip))).start();
	        }
	        	else{
	    	        Clip clip = AudioSystem.getClip();
	    	        clip.open(audioIn);
	    	        clip.start();
	        	}
	        		
	        
	        }
	    } catch (Exception e) {
	       
	    	e.printStackTrace();
	   }
	}
	
	
	
	@Override
	public void windowActivated(WindowEvent e) {

		
	}

	@Override
	public void windowClosed(WindowEvent e) {

	}

	@Override
	public void windowClosing(WindowEvent e) {

		    System.exit(0);
	}

	@Override
	public void windowDeactivated(WindowEvent e) {

	}

	@Override
	public void windowDeiconified(WindowEvent e) {

		
	}

	@Override
	public void windowIconified(WindowEvent e) {

		
	}

	@Override
	public void windowOpened(WindowEvent e) {

		
	}


//401,57

	
	static JFileChooser chooser;
	 static String choosertitle;
	public boolean gotoplay=false;

	   
		public void save(String[] args) {
			 @SuppressWarnings("unused")
			int result;
		        

			 
			    chooser = new JFileChooser(); 
			    chooser.setCurrentDirectory(new java.io.File("."));
			    chooser.setDialogTitle(choosertitle);
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
				File file;
				
				
				System.out.println("Da thingie is");
				System.out.println(chooser.getSelectedFile().getName().length());
				
				

				
				if (!chooser.getSelectedFile().getName().endsWith(".mylegguy")){
					file =  new File(chooser.getSelectedFile()+".mylegguy");
				}
				else
				{
					file =  new File(chooser.getSelectedFile()+"");
				}
				
				
				String content="";
				if (maxx<100 && maxx>=10){content = "0"+Integer.toString(maxx);}
				if (maxx<10){content = "00"+Integer.toString(maxx);}
				if (maxx>100){content = Integer.toString(maxx);}
				
				System.out.println(content);
			    
				for(int iy=0; iy<14; iy++){
			    	 for(int ix=0; ix<400; ix++){
			    	content+=world[ix][iy];
			    	 }
			    }
			    
			    	 //File file = new File("filename.mylegguy");
			    	 file.delete();
			    	 
			    	 file.createNewFile();
	 
				FileWriter fw = new FileWriter(file.getAbsoluteFile());
				BufferedWriter bw = new BufferedWriter(fw);
				bw.write(content);
				bw.close();
	 
				System.out.println("Done");
	 
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
	
	
		  public void load(String[] args) throws Exception {
		      

			  
		      InputStream is = null;
		      int i;
		      char c;
		      
			    JFileChooser chooser = new JFileChooser();
			    chooser.setCurrentDirectory(new java.io.File("."));
			    FileNameExtensionFilter filter = new FileNameExtensionFilter(
			        ".mylegguy files", "mylegguy");
			    chooser.setFileFilter(filter);
			    int returnVal = chooser.showOpenDialog(chooser);
			    if(returnVal == JFileChooser.APPROVE_OPTION) {
			      // System.out.println("You chose to open this file: " +
			           // chooser.getSelectedFile().getName());
			       is = new FileInputStream(chooser.getSelectedFile());
				      try{
					         // new input stream created
					         //is = new FileInputStream("filename.mylegguy");
					         
					         int rxa=0;
					         int rya=0;
					         
					         System.out.println("Characters printed:");
					         
					         // reads till the end of the stream
					         //while((i=is.read())!=-1)
					         //System.out.println("Rya:"+rya);
					         String temp="";
					         
					         i=is.read();
					         c=(char)i;
					         System.out.println(c);
					         temp=temp+c;
					         System.out.println(temp);
					         i=is.read();
					         c=(char)i;
					         System.out.println(c);
					         temp=temp+c;
					         System.out.println(temp);
					         i=is.read();
					         c=(char)i;
					         System.out.println(c);
					         temp=temp+c;
					         System.out.println(temp);
					         maxx=Integer.parseInt(temp);
					         System.out.println("---");
					         System.out.println(maxx);
					         while(true)
					         {
					            // converts integer to character
					        	 //System.out.println(rya);
					        	 i=is.read();
					        	 if (rxa==400){
					        		 rya=rya+1;
					        		 rxa=0;
					        		 //System.out.println("Rya :"+rya);
					        		 System.out.println("Changed levels");
					        		 
					        		 if (rya==14){
					        			return;
					        		 }
					        	 }
					        	 
					        	 c=(char)i;
					        	 

					        	 world[rxa][rya]=Character.getNumericValue(i);
					        	 System.out.println(world[rxa][rya]);
					        	 //c=(char)i;
					            rxa+=1;
					            //System.out.println(rxa);
					            // prints character
					            //System.out.print(c);
					         }
					      }catch(Exception e){
					         
					         // if any I/O error occurs
					         e.printStackTrace();
					      }finally{
					         
					         // releases system resources associated with this stream
					         if(is!=null)
					            is.close();
					      }
			    }
		      

		   }
	

public void playnote(int lex, int i){
	int oldpianox=pianox;
	
	pianox=lex;
	
	if (world[pianox][i]==1){
		if (i==0){
			PlaySound("piano_high_b.wav");
		}
		if (i==1){
			PlaySound("piano_high_a.wav");	
		}
		if (i==2){
			PlaySound("piano_high_g.wav");
		}
		if (i==3){
			PlaySound("piano_high_f.wav");
		}
		if (i==4){
			PlaySound("piano_high_e.wav");	
		}
		if (i==5){
			PlaySound("piano_high_d.wav");
		}
		if (i==6){
			PlaySound("piano_c.wav");	
		}
		if (i==7){
			PlaySound("piano_b.wav");
		}
		if (i==8){
			PlaySound("piano_a.wav");	
		}
		if (i==9){
			PlaySound("piano_g.wav");	

		}
		if (i==10){
			PlaySound("piano_f.wav");

		}
		if (i==11){
			PlaySound("piano_e.wav");

		}
		if (i==12){
			PlaySound("piano_low_d.wav");	

		}
		if (i==13){
			PlaySound("piano_low_c.wav");	

		}
		
	}
	if (world[pianox][i]==2){
		if (i==0){
			PlaySound("piano_high_c.wav");
		}
		if (i==1){
			PlaySound("piano_high_a_sharp.wav");	
		}
		if (i==2){
			PlaySound("piano_high_g_sharp_a_flat.wav");	
		}
		if (i==3){
			PlaySound("piano_high_f_sharp.wav");	
		}
		if (i==4){
			PlaySound("piano_high_f.wav");	
		}
		if (i==5){
			PlaySound("piano_d_sharp_e_flat.wav");	
		}
		if (i==6){
			PlaySound("piano_c_sharp_d_flat.wav");	
		}
		if (i==7){
			PlaySound("piano_c.wav");	
		}
		if (i==8){
			PlaySound("piano_a_sharp_b_flat.wav");	
		}
		if (i==9){
			PlaySound("piano_g_sharp_a_flat.wav");	
		}
		if (i==10){
			PlaySound("piano_f_sharp_g_flat.wav");	
		}
		if (i==11){
			PlaySound("piano_f.wav");	
		}
		if (i==12){
			PlaySound("piano_low_d_sharp_e_flat.wav");	
		}
		if (i==13){
			PlaySound("piano_low_c_sharp_or_d_flat.wav");	
		}
		
	}
	if (world[pianox][i]==3){
		if (i==0){
			PlaySound("piano_high_a_sharp.wav");
		}
		if (i==1){
			PlaySound("piano_high_g_sharp_a_flat.wav");	
		}
		if (i==2){
			PlaySound("piano_high_f_sharp_g_flat.wav");	
		}
		if (i==3){
			PlaySound("piano_high_e.wav");	
		}
		if (i==4){
			PlaySound("piano_d_sharp_e_flat.wav");	
		}
		if (i==5){
			PlaySound("piano_c_sharp_d_flat.wav");	
		}
		if (i==6){
			PlaySound("piano_b.wav");	
		}
		if (i==7){
			PlaySound("piano_a_sharp_b_flat.wav");	
		}
		if (i==8){
			PlaySound("piano_g_sharp_a_flat.wav");	
		}
		if (i==9){
			PlaySound("piano_f_sharp_g_flat.wav");	
		}
		if (i==10){
			PlaySound("piano_e.wav");	
		}
		if (i==11){
			PlaySound("piano_low_d_sharp_e_flat.wav");	
		}
		if (i==12){
			PlaySound("piano_low_c_sharp_or_d_flat.wav");	
		}
		if (i==13){
			PlaySound("piano_c_flat_which_is_b.wav");	
		}
		
	}
	
	if (world[pianox][i]==4){
		System.out.println("Played bass");
		if (i==0){
			PlaySound("bass_high_b.wav");
		}
		if (i==1){
			PlaySound("bass_a.wav");	
		}
		if (i==2){
			PlaySound("bass_g.wav");
		}
		if (i==3){
			PlaySound("bass_f.wav");
		}
		if (i==4){
			PlaySound("bass_e.wav");	
		}
		if (i==5){
			PlaySound("bass_d.wav");
		}
		if (i==6){
			PlaySound("bass_c.wav");	
		}
		if (i==7){
			PlaySound("bass_b.wav");
		}
		if (i==8){
			PlaySound("bass_low_a.wav");	
		}
		if (i==9){
			PlaySound("bass_low_g.wav");	

		}
		if (i==10){
			PlaySound("bass_low_f.wav");

		}
		if (i==11){
			PlaySound("bass_low_e.wav");

		}
		if (i==12){
			PlaySound("bass_low_d.wav");	

		}
		if (i==13){
			PlaySound("bass_low_c.wav");	

		}
		
	}
	if (world[pianox][i]==5){
		if (i==0){
			PlaySound("bass_high_c.wav");
		}
		if (i==1){
			PlaySound("bass_b_flat_a_sharp.wav");	
		}
		if (i==2){
			PlaySound("bass_a_flat_g_sharp.wav");	
		}
		if (i==3){
			PlaySound("bass_g_flat_f_sharp.wav");	
		}
		if (i==4){
			PlaySound("bass_f.wav");	
		}
		if (i==5){
			PlaySound("bass_e_flat_d_sharp.wav");	
		}
		if (i==6){
			PlaySound("bass_d_flat_c_sharp.wav");	
		}
		if (i==7){
			PlaySound("bass_c.wav");	
		}
		if (i==8){
			PlaySound("bass_low_b_flat_a_sharp.wav");	
		}
		if (i==9){
			PlaySound("bass_low_a_flat_g_sharp.wav");	
		}
		if (i==10){
			PlaySound("bass_low_g_flat_f_sharp.wav");	
		}
		if (i==11){
			PlaySound("bass_low_f.wav");	
		}
		if (i==12){
			PlaySound("bass_low_e_flat_d_sharp.wav");	
		}
		if (i==13){
			PlaySound("bass_low_d_flat_c_sharp.wav");	
		}
		
	}
	if (world[pianox][i]==6){
		if (i==0){
			PlaySound("bass_b_flat_a_sharp.wav");
		}
		if (i==1){
			PlaySound("bass_a_flat_g_sharp.wav");	
		}
		if (i==2){
			PlaySound("bass_g_flat_f_sharp.wav");	
		}
		if (i==3){
			PlaySound("bass_e.wav");	
		}
		if (i==4){
			PlaySound("bass_e_flat_d_sharp.wav");	
		}
		if (i==5){
			PlaySound("bass_d_flat_c_sharp.wav");	
		}
		if (i==6){
			PlaySound("bass_b.wav");	
		}
		if (i==7){
			PlaySound("bass_b_flat_a_sharp.wav");	
		}
		if (i==8){
			PlaySound("bass_low_a_flat_g_sharp.wav");	
		}
		if (i==9){
			PlaySound("bass_low_g_flat_f_sharp.wav");	
		}
		if (i==10){
			PlaySound("bass_low_e.wav");	
		}
		if (i==11){
			PlaySound("bass_low_e_flat_d_sharp.wav");	
		}
		if (i==12){
			PlaySound("bass_low_d_flat_c_sharp.wav");	
		}
		if (i==13){
			PlaySound("bass_low_b.wav");	
		}
		
	}
	
	if (world[pianox][i]==7){
		if (i==0){
			PlaySound("drum_0.wav");
		}
		if (i==1){
			PlaySound("drum_1.wav");	
		}
		if (i==2){
			PlaySound("drum_2.wav");	
		}
		if (i==3){
			PlaySound("drum_3.wav");	
		}
		if (i==4){
			PlaySound("drum_4.wav");	
		}
		if (i==5){
			PlaySound("drum_5.wav");	
		}
		if (i==6){
			PlaySound("drum_6.wav");	
		}
		if (i==7){
			PlaySound("drum_0.wav");	
		}
		if (i==8){
			PlaySound("drum_1.wav");	
		}
		if (i==9){
			PlaySound("drum_2.wav");	
		}
		if (i==10){
			PlaySound("drum_3.wav");	
		}
		if (i==11){
			PlaySound("drum_4.wav");	
		}
		if (i==12){
			PlaySound("drum_5.wav");	
		}
		if (i==13){
			PlaySound("drum_6.wav");	
		}
		
	}
	
	pianox=oldpianox;
	
}

void preload()
{
	PlaySound("piano_high_b.wav");
	PlaySound("piano_high_a.wav");	
	PlaySound("piano_high_g.wav");
	PlaySound("piano_high_f.wav");
	PlaySound("piano_high_e.wav");	
	PlaySound("piano_high_d.wav");
	PlaySound("piano_c.wav");	
	PlaySound("piano_b.wav");
	PlaySound("piano_a.wav");	
	PlaySound("piano_g.wav");	
	PlaySound("piano_f.wav");
	PlaySound("piano_e.wav");
	PlaySound("piano_low_d.wav");	
	PlaySound("piano_low_c.wav");	
	PlaySound("piano_high_c.wav");
	PlaySound("piano_high_a_sharp.wav");	
	PlaySound("piano_high_g_sharp_a_flat.wav");	
	PlaySound("piano_high_f_sharp.wav");	
	PlaySound("piano_high_f.wav");	
	PlaySound("piano_d_sharp_e_flat.wav");	
	PlaySound("piano_c_sharp_d_flat.wav");	
	PlaySound("piano_c.wav");	
	PlaySound("piano_a_sharp_b_flat.wav");	
	PlaySound("piano_g_sharp_a_flat.wav");	
	PlaySound("piano_f_sharp_g_flat.wav");	
	PlaySound("piano_f.wav");	
	PlaySound("piano_low_d_sharp_e_flat.wav");	
	PlaySound("piano_low_c_sharp_or_d_flat.wav");	
	PlaySound("piano_high_a_sharp.wav");
	PlaySound("piano_high_g_sharp_a_flat.wav");	
	PlaySound("piano_high_f_sharp_g_flat.wav");	
	PlaySound("piano_high_e.wav");	
	PlaySound("piano_d_sharp_e_flat.wav");	
	PlaySound("piano_c_sharp_d_flat.wav");	
	PlaySound("piano_b.wav");	
	PlaySound("piano_a_sharp_b_flat.wav");	
	PlaySound("piano_g_sharp_a_flat.wav");	
	PlaySound("piano_f_sharp_g_flat.wav");	
	PlaySound("piano_e.wav");	
	PlaySound("piano_low_d_sharp_e_flat.wav");	
	PlaySound("piano_low_c_sharp_or_d_flat.wav");	
	PlaySound("piano_c_flat_which_is_b.wav");	
	PlaySound("bass_high_b.wav");
	PlaySound("bass_a.wav");	
	PlaySound("bass_g.wav");
	PlaySound("bass_f.wav");
	PlaySound("bass_e.wav");	
	PlaySound("bass_d.wav");
	PlaySound("bass_c.wav");	
	PlaySound("bass_low_b.wav");
	PlaySound("bass_low_a.wav");	
	PlaySound("bass_low_g.wav");	
	PlaySound("bass_low_f.wav");
	PlaySound("bass_low_e.wav");
	PlaySound("bass_low_d.wav");	
	PlaySound("bass_low_c.wav");	
	PlaySound("bass_high_c.wav");
	PlaySound("bass_b_flat_a_sharp.wav");	
	PlaySound("bass_a_flat_g_sharp.wav");	
	PlaySound("bass_g_flat_f_sharp.wav");	
	PlaySound("bass_f.wav");	
	PlaySound("bass_e_flat_d_sharp.wav");	
	PlaySound("bass_d_flat_c_sharp.wav");	
	PlaySound("bass_c.wav");	
	PlaySound("bass_low_b_flat_a_sharp.wav");	
	PlaySound("bass_low_a_flat_g_sharp.wav");	
	PlaySound("bass_low_g_flat_f_sharp.wav");	
	PlaySound("bass_low_f.wav");	
	PlaySound("bass_low_e_flat_d_sharp.wav");	
	PlaySound("bass_low_d_flat_c_sharp.wav");	
	PlaySound("bass_b_flat_a_sharp.wav");
	PlaySound("bass_a_flat_g_sharp.wav");	
	PlaySound("bass_g_flat_f_sharp.wav");	
	PlaySound("bass_e.wav");	
	PlaySound("bass_e_flat_d_sharp.wav");	
	PlaySound("bass_d_flat_c_sharp.wav");	
	PlaySound("bass_b.wav");	
	PlaySound("bass_b_flat_a_sharp.wav");	
	PlaySound("bass_low_a_flat_g_sharp.wav");	
	PlaySound("bass_low_g_flat_f_sharp.wav");	
	PlaySound("bass_low_e.wav");	
	PlaySound("bass_low_e_flat_d_sharp.wav");	
	PlaySound("bass_low_d_flat_c_sharp.wav");	
	PlaySound("bass_low_b.wav");	
	PlaySound("drum_0.wav");
	PlaySound("drum_1.wav");	
	PlaySound("drum_2.wav");	
	PlaySound("drum_3.wav");	
	PlaySound("drum_4.wav");	
	PlaySound("drum_5.wav");	
	PlaySound("drum_6.wav");	
	PlaySound("drum_0.wav");	
	PlaySound("drum_1.wav");	
	PlaySound("drum_2.wav");	
	PlaySound("drum_3.wav");	
	PlaySound("drum_4.wav");	
	PlaySound("drum_5.wav");	
	PlaySound("drum_6.wav");	
}


void saveoptions(){

	  File file = new File("Options.mylegguy");
  	 file.delete();
	
  	 String content="";
  	 
  			 content=content+theme;
  	if (playOnPlace){content=content+1;} else {content=content+0;}
  	if (dopreload){content=content+1;} else {content=content+0;}
  	if (line){content=content+1;} else {content=content+0;}	
  	if (closesounds){content=content+1;} else {content=content+0;}	
  	
  	System.out.println("====");
  	
  	System.out.println(bpm);
  	
  	if (bpm<100){
  		content=content+"0";
  				content=content+(int)bpm;
  				} else 
  				{
  					content=content+(int)bpm;
  					}	
  	
  	System.out.println(content);
  	
  	System.out.println("DA START");
  	
  	System.out.println(content);
  	
  	
  	if (saveButton.getx()<100 && saveButton.getx()>9){
  		content=content+"0"+saveButton.getx();
  		}
  	if (saveButton.getx()>99){
  		content=content+saveButton.getx();
  		}
  	if (saveButton.getx()<10){
  		content=content+"00"+saveButton.getx();
  		}
  	if (saveButton.gety()<100 && saveButton.gety()>9){
  		content=content+"0"+saveButton.gety();
  		}
  	if (saveButton.gety()>99){
  		content=content+saveButton.gety();
  		}
  	if (saveButton.gety()<10){
  		content=content+"00"+saveButton.gety();
  		}
  	//System.out.println(content);
  	//////////////////////
  	if (loadButton.getx()<100 && loadButton.getx()>9){
  		content=content+"0"+loadButton.getx();
  		}
  	if (loadButton.getx()>99){
  		content=content+loadButton.getx();
  		}
  	if (loadButton.getx()<10){
  		content=content+"00"+loadButton.getx();
  		}
  	if (loadButton.gety()<100 && loadButton.gety()>9){
  		content=content+"0"+loadButton.gety();
  		}
  	if (loadButton.gety()>99){
  		content=content+loadButton.gety();
  		}
  	if (loadButton.gety()<10){
  		content=content+"00"+loadButton.gety();
  		}
  //	System.out.println(content);
  	////////////
  	if (leftButton.getx()<100 && leftButton.getx()>9){
  		content=content+"0"+leftButton.getx();
  		}
  	if (leftButton.getx()>99){
  		content=content+leftButton.getx();
  		}
  	if (leftButton.getx()<10){
  		content=content+"00"+leftButton.getx();
  		}
  	if (leftButton.gety()<100 && leftButton.gety()>9){
  		content=content+"0"+leftButton.gety();
  		}
  	if (leftButton.gety()>99){
  		content=content+leftButton.gety();
  		}
  	if (leftButton.gety()<10){
  		content=content+"00"+leftButton.gety();
  		}
 // 	System.out.println(content);
  ///////////
  	if (rightButton.getx()<100 && rightButton.getx()>9){
  		content=content+"0"+rightButton.getx();
  		}
  	if (rightButton.getx()>99){
  		content=content+rightButton.getx();
  		}
  	if (rightButton.getx()<10){
  		content=content+"00"+rightButton.getx();
  		}
  	if (rightButton.gety()<100 && rightButton.gety()>9){
  		content=content+"0"+rightButton.gety();
  		}
  	if (rightButton.gety()>99){
  		content=content+rightButton.gety();
  		}
  	if (rightButton.gety()<10){
  		content=content+"00"+rightButton.gety();
  		}
  //	System.out.println(content);
  	//
  	if (playButton.getx()<100 && playButton.getx()>9){
  		content=content+"0"+playButton.getx();
  		}
  	if (playButton.getx()>99){
  		content=content+playButton.getx();
  		}
  	if (playButton.getx()<10){
  		content=content+"00"+playButton.getx();
  		}
  	if (playButton.gety()<100 && playButton.gety()>9){
  		content=content+"0"+playButton.gety();
  		}
  	if (playButton.gety()>99){
  		content=content+playButton.gety();
  		}
  	if (playButton.gety()<10){
  		content=content+"00"+playButton.gety();
  		}
 // 	System.out.println(content);
  	
  	
  	if (theme==5){
  		if (custompath.length()<10){content=content+"0";}
  		content=content+custompath.length();
  		content=content+custompath;
  	}
  	
  	//		 System.out.println("Final content:"+content);
  			 
  	 FileWriter fw = null;
			try {
				fw = new FileWriter(file.getAbsoluteFile());
			} catch (IOException e2) {
				e2.printStackTrace();
			}
			BufferedWriter bw = new BufferedWriter(fw);
			try {
				bw.write(content);
			} catch (IOException e2) {
				
				e2.printStackTrace();
			}
			try {
				bw.close();
			} catch (IOException e2) {

				e2.printStackTrace();
			}
  	 try {
			file.createNewFile();
		} catch (IOException e1) {

			e1.printStackTrace();
		}
	
}


@Override
public void keyPressed(KeyEvent k) {

	if (canpress){
//	System.out.println(k.getKeyCode());

		
		switch(k.getKeyCode()){

	
	
case KeyEvent.VK_B:{
	running=true;
	playing=false;
	break;
}

case KeyEvent.VK_A:{
	if (page!=1){page-=1;
	offset-=25;}
	canpress=false;
	
	break;
}

case KeyEvent.VK_1:{
	NotePiano.note=0;
	break;
}
case KeyEvent.VK_2:{
	NotePiano.note=1;
	break;
}
case KeyEvent.VK_3:{
	NotePiano.note=2;
	break;
}
case KeyEvent.VK_4:{
	NotePiano.note=3;
	break;
}
case KeyEvent.VK_5:{
	NotePiano.note=4;
	break;
}
case KeyEvent.VK_6:{
	NotePiano.note=5;
	break;
}
case KeyEvent.VK_7:{
	NotePiano.note=6;
	break;
}
case KeyEvent.VK_8:{
	NotePiano.note=7;
	break;
}
case KeyEvent.VK_9:{
	NotePiano.note=8;
	break;
}
case KeyEvent.VK_S:{
	if (page!=16)
	{page+=1;
	offset+=25;}
	canpress=false;
	break;
}
case KeyEvent.VK_W:{
	try {
		save(null);
		canpress=false;
	} catch (Exception e) {
		e.printStackTrace();
	}
	break;
}
case KeyEvent.VK_Q:{
	try {
		load(null);
	} catch (Exception e) {
		
		e.printStackTrace();
	}
	canpress=false;
	break;
}
case KeyEvent.VK_SPACE:{

	if (running==true && canpress==true && spacebar){
	//	System.out.println(offset);
		System.out.println("Activated");
		if (closesounds==true && playOnPlace==true){
	         for(int i=0; i<currentclip-1; i++){
	              clips[i].close();
	              System.out.println("Closed sound"+i+" .");
	         }
	       currentclip=0;
		}
		oldoffset=offset;
		offset=0;
		page=1;
		running=false;
	playing=true;
	pianox=-1;
	canpress=false;
	spacebar=false;
//	System.out.println(oldoffset);
	}
	else if(playing==true && canpress==true && spacebar){

		System.out.println("Deactivated");
	running=true;
	playing=false;
	pianox=1;
	canpress=false;
	spacebar=false;
	offset=oldoffset;
	page=((offset+25))/25;
	System.out.println(offset);
	
	if (closesounds==true){
        for(int i=0; i<currentclip-1; i++){
             clips[i].close();
             System.out.println("Closed sound"+i+" .");
        }
      currentclip=0;
	}
	
	}
	
	
	break;
}

case KeyEvent.VK_K:{
	keyb=true;
	canpress=false;
	break;
	
}

case KeyEvent.VK_C:{
	NotePiano.note+=1;
	if (NotePiano.note==9){
		NotePiano.note=0;
	}
	break;
	
}

}
}
	
}


@Override
public void keyReleased(KeyEvent e) {
	canpress=true; spacebar=true;
	
}


@Override
public void keyTyped(KeyEvent e) {
	
}


public void gotothemeshop(){


URL url;
InputStream is = null;
URLConnection con;
try {
	url = new URL("http://www.mylegguy.x10.mx/GrowtopiaMusicSimulatorThemes/themes.mylegguy");
	con = url.openConnection();
	is =con.getInputStream();
} catch (IOException e1) {
	
	JOptionPane.showMessageDialog(null,
		    "Could not connect to the Theme list thingie.\nCheck your internet connection or try again later.",
		    "Sad face.",
		    JOptionPane.WARNING_MESSAGE);
	e1.printStackTrace();
}

BufferedReader br = new BufferedReader(new InputStreamReader(is));

String line = null;

// read each line and write to System.out
try {
	while ((line = br.readLine()) != null) {
	    System.out.println(line);
	    themestrings[daint]=line;
	    daint+=1;
	}
} catch (IOException e) {
	
	JOptionPane.showMessageDialog(null,
		    "Uh... bad stuff happend...\nSorry about that.",
		    "Sad face.",
		    JOptionPane.WARNING_MESSAGE);
	e.printStackTrace();
}




}


public static void saveImage(String imageUrl, String destinationFile) throws IOException {
	URL url = new URL(imageUrl);
	InputStream is = url.openStream();
	OutputStream os = new FileOutputStream(destinationFile);

	byte[] b = new byte[2048];
	int length;

	while ((length = is.read(b)) != -1) {
		os.write(b, 0, length);
	}

	is.close();
	os.close();
}


}
