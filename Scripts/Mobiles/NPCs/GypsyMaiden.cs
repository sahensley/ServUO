#region References
using Server.Items;
using System.Collections.Generic;
#endregion

namespace Server.Mobiles
{
    public class GypsyMaiden : BaseVendor
    {
        private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();

        [Constructable]
        public GypsyMaiden()
            : base("the gypsy maiden")
        {
            SetSkill(SkillName.Begging, 64.0, 100.0);
        }

        public GypsyMaiden(Serial serial)
            : base(serial)
        { }

        protected override List<SBInfo> SBInfos => m_SBInfos;

        public override bool GetGender()
        {
            return true; // always female
        }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBProvisioner());
        }

        public override void InitOutfit()
        {
            base.InitOutfit();

            switch (Utility.Random(4))
			{
				case 0:
					SetWearable(new JesterHat(), Utility.RandomBrightHue(), 1);
					break;
				case 1:
					SetWearable(new Bandana(), Utility.RandomBrightHue(), 1);
					break;
				case 2:
					SetWearable(new SkullCap(), Utility.RandomBrightHue(), 1);
					break;
			}

            if (Utility.RandomBool())
            {
                SetWearable(new HalfApron(), Utility.RandomBrightHue(), 1);
            }

            Item item = FindItemOnLayer(Layer.Pants);

            if (item != null)
            {
                item.Hue = Utility.RandomBrightHue();
            }

            item = FindItemOnLayer(Layer.OuterLegs);

            if (item != null)
            {
                item.Hue = Utility.RandomBrightHue();
            }

            item = FindItemOnLayer(Layer.InnerLegs);

            if (item != null)
            {
                item.Hue = Utility.RandomBrightHue();
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}