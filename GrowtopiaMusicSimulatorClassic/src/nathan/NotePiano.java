package nathan;
import java.awt.*;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.image.BufferedImage;
import java.io.IOException;
import javax.imageio.ImageIO;


public class NotePiano implements KeyListener{

	static Image[] image = new Image[9];
	//8
	static boolean canpress=true;
	int x;
	int y;
	static int note=1;
	public static BufferedImage img = null;
	boolean keyb=false;
	
	MainClass mca;
	
	boolean spacebar=true;
	
	public NotePiano(MainClass mc){

		mca=mc;
		
		
		
		try {		
			image[0] = ImageIO.read(getClass().getResourceAsStream("eraser.png"));
			image[1] = ImageIO.read(getClass().getResourceAsStream("PianoNote.png"));
			image[2] = ImageIO.read(getClass().getResourceAsStream("Piano_sharp.png"));
			image[3] = ImageIO.read(getClass().getResourceAsStream("Piano_flat.png"));
			image[7] = ImageIO.read(getClass().getResourceAsStream("Drum.png"));
			image[4] = ImageIO.read(getClass().getResourceAsStream("Bass.png"));
			image[8] = ImageIO.read(getClass().getResourceAsStream("Piano_blank.png"));
			image[5] = ImageIO.read(getClass().getResourceAsStream("Sharp_Bass.png"));
			image[6] = ImageIO.read(getClass().getResourceAsStream("Flat_Bass.png"));
		} catch (IOException a) {
		}
		
	}
	
	public void update(MainClass mc){
	
		//mc.addKeyListener(this);
	}
	
	public void paint(Graphics g, MainClass mc){
		g.drawImage(image[note], x, y, mc);
		g.drawImage(image[note], x, y, mc);
	}


	
	@Override
	public void keyPressed(KeyEvent k) {		
		
		//System.out.println(KeyEvent.VK_SPACE);
		//System.out.println("Pressed a key. Canpress:" + canpress);
		
	}

	@Override
	public void keyReleased(KeyEvent arg0) {canpress=true; spacebar=true;}

	@Override
	public void keyTyped(KeyEvent arg0) {}

	
	
	
	public int randomInt(int min, int max) {
	    int randomNum = min + (int)(Math.random() * ((max - min) + 1));
	    return randomNum;
	}

	
}
