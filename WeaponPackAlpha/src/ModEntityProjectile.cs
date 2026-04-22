using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.GameContent;

namespace CustomWeaponSpeed
{
    public class ModEntityProjectile : EntityProjectile
    {
        protected override bool DealDamage(Entity target)
        {
            bool fromPlayer = FiredBy is EntityPlayer;

            float damage = Damage;
            ApplyModifiers(ref damage, target);

            bool didDamage = target.ReceiveDamage(new DamageSource()
            {
                Source = fromPlayer ? EnumDamageSource.Player : EnumDamageSource.Entity,
                SourceEntity = this,
                CauseEntity = FiredBy,
                Type = DamageType,
                DamageTier = DamageTier,
                IgnoreInvFrames = IgnoreInvFrames,
                KnockbackStrength = 0.5f,
                YDirKnockbackDiv = 3f
            }, damage);

            return didDamage;
        }
    }
}
