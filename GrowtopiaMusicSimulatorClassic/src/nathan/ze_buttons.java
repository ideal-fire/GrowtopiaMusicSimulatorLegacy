package nathan;

import java.awt.Graphics;
import java.awt.image.BufferedImage;

public class ze_buttons {
	
	int myx, myy, mywidth,myheight;
	BufferedImage myimage, myimage2;
	MainClass mainClass;
	
	public ze_buttons(int myx, int myy, int mywidth, int myheight, BufferedImage myimage, BufferedImage myimage2, MainClass mainClass){
		this.myx=myx;
		this.myy=myy;
		this.mywidth=mywidth;
		this.myheight=myheight;
		this.myimage = myimage;
		this.myimage2 = myimage2;
		this.mainClass = mainClass;
	}
	public void setx(int a){
		myx=a;
	}
	public void sety(int a){
		myy=a;
	}
	public int getx(){
		return myx;
	}
	public int gety(){
		return myy;
	}
	public int getwidth(){
		return mywidth;
	}
	public int getheight(){
		return myheight;
	}
	public int getwidthEdge(){
		return mywidth + myx;
	}
	public int getheightEdge(){
		return myheight + myy;
	}
	public BufferedImage getimage(){
		return myimage;
	}
	public BufferedImage getimage2(){
		return myimage2;
	}
	
	public void draw(Graphics g)
	{
		g.drawImage(myimage,myx,myy,mainClass);
	}
}
