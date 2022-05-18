//Plugin template for plugin system v1.0
//Author     : put your name here
//Date       : date of this version
//Version    : the version of this plugin
//Description: explain what your plugin do
//Usage      : how to use this plugin

//Assemblies needed for GEAR plugin system (do not delete them).
using System;
using Gear.EmulationCore;
using Gear.PluginSupport;
//Add here extra assemblies as needed in your plugin.

//Class name of your plugin. You must change it to avoid conflics with others.
//Also, it must match class name on plugin editor text box
class YourPluginClassName : PluginBase
{
	//Constructor for the initialization of your plugin
	public YourPluginClassName(PropellerCPU chip) : base(chip)
	{
		//Include here your initialization code only for attributes you add to
		//  your class or interface objects (example create user controls for
		//  the tab window). If you don't use any, don't add code here, but you
		//  must not delete this method.
		//If you wish to use DrivePin() for initial setup of pins, call it
		//  inside of OnReset() method, instead of here.
		OnReset();  //don't delete this

		// Put your code here:

	}

	//Title to be shown in tab. You must change to your plugin name.
	public override string Title
	{
		get { return "My Plugin"; }  //change to your plugin name
	}

	//Register the events to be notified to this plugin and occurs once the
	//plugin is loaded.
	//Also, if you need the plugin be notified on pin or clock changes, you 
	//need to add inside this method calls to NotifyOnPins or NotifyOnClock. 
	//To keep good performance, use only the essentials ones.
	public override void PresentChip()
	{
		//To be notified on changed pins (ex. DIRx, OUTx, INx) use here:
		//  NotifyOnPins();
		//To be notified on each clock tick, use here:
		//  NotifyOnClock();
		//
		//Put your code here:
	}

	//Called every time a pin changes, if called Chip.NotifyOnPins() in
	//  method PresentChip(.) above.
	//Warning: to assure the correct correct operation of the plugin system,
	//  you can't change the parameters of any predefined method: neither the
	//  names or the types. Also you must not add other parameters.
	public override void OnPinChange(double time, PinState[] pinStates)
	{
		//You could set or test pin states like "pinStates[0] == PinState.FLOATING;"
		//  or "if (pinStates[1] == PinState.FLOATING)..."
		//Possible values for PinState enum are:
		//  FLOATING, OUTPUT_LO, OUTPUT_HI, INPUT_LO, INPUT_HI.
		//
		//Put your code here.

	}

	//Called every clock tick, if called Chip.NotifyOnClock() in method
	//  PresentChip() above.
	//Warning: to assure the correct correct operation of the plugin system,
	//  you can't change the parameters of any predefined method: neither the
	//  names or the types. Also you must not add other parameters.
	public override void OnClock(double time, uint sysCounter)
	{
		//Put your code here.
	}

	//Called when you press the Reset button, to reset the plugin to a
	//  initial state.
	public override void OnReset()
	{
		//For initial setup of the plugin (but not the creation of interface
		//  objects), you can add your code here. The idea if you have to reset
		//  the pins state, you can use here the DrivePin() method. Example:
		//  DrivePin(int pin_number, bool isFloating, bool isHigh);
		//
		//Put your code here.

	}

}
