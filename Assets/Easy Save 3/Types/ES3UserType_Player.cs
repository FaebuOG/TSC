using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("instance", "rb", "inventory", "DialogueState", "pickedUpMoney", "textPickedUpMoney", "enabled", "name")]
	public class ES3UserType_Player : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Player() : base(typeof(Player)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Player)obj;
			
			writer.WritePropertyByRef("instance", Player.instance);
			writer.WritePrivateFieldByRef("rb", instance);
			writer.WritePropertyByRef("inventory", instance.inventory);
			writer.WriteProperty("DialogueState", instance.DialogueState, ES3Type_enum.Instance);
			writer.WritePropertyByRef("pickedUpMoney", instance.pickedUpMoney);
			writer.WritePropertyByRef("textPickedUpMoney", instance.textPickedUpMoney);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Player)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "instance":
						Player.instance = reader.Read<Player>();
						break;
					case "rb":
					reader.SetPrivateField("rb", reader.Read<UnityEngine.Rigidbody>(), instance);
					break;
					case "inventory":
						instance.inventory = reader.Read<InventoryObject>();
						break;
					case "DialogueState":
						instance.DialogueState = reader.Read<DialogueState>(ES3Type_enum.Instance);
						break;
					case "pickedUpMoney":
						instance.pickedUpMoney = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "textPickedUpMoney":
						instance.textPickedUpMoney = reader.Read<UnityEngine.UI.Text>(ES3Type_Text.Instance);
						break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_PlayerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PlayerArray() : base(typeof(Player[]), ES3UserType_Player.Instance)
		{
			Instance = this;
		}
	}
}