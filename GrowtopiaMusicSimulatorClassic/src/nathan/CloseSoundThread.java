package nathan;

import javax.sound.sampled.Clip;



public class CloseSoundThread implements Runnable {

	public static Clip a;
	@SuppressWarnings("static-access")
	public CloseSoundThread(Clip a)
	{
		this.a = a;
	}
	
    public void run() {
        System.out.println("a - thread");
    	try {
			Thread.sleep(3000);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
        a.close();
    }



}