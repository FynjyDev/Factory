using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DeliverySpot : ItemsChanger
{
    [SerializeField] private Slider deliveryTimeSlider;
    [SerializeField] private Stack deliverySpotStack;
    [SerializeField] private InteractPoint interactPoint;
    [SerializeField] private Animator deliverySpotAnimator;

    private int maxItemsCount => SingletonController.singletonController.Config.MaxItemsCount;
    private int deliveryDelay => SingletonController.singletonController.Config.DeliveryDelay;

    public override void OnInteractStart()
    {
        if (TempItemCount >= maxItemsCount) return;
        base.OnInteractStart();
    }

    public override void OnChange()
    {
        base.OnChange();

        deliverySpotStack.AddElement();

        if (TempItemCount == maxItemsCount)
        {
            StopAllCoroutines();
            StartCoroutine(DeliverTimer());
            return;
        }
    }

    private IEnumerator DeliverTimer()
    {
        deliveryTimeSlider.gameObject.SetActive(true);
        interactPoint.gameObject.SetActive(false);
        deliverySpotAnimator.SetTrigger("Start");

        deliveryTimeSlider.maxValue = deliveryDelay;

        float _deliveryDelayTemp = 0;

        while (_deliveryDelayTemp < deliveryDelay)
        {
            deliveryTimeSlider.value = _deliveryDelayTemp;
            _deliveryDelayTemp += Time.fixedDeltaTime;
            yield return null;
        }

        deliverySpotAnimator.SetTrigger("End");
        deliverySpotStack.ClearStack();
    }

    public void DeliveryAnimatioEnd()
    {
        OnDeliveryEnd();
    }

    private void OnDeliveryEnd()
    {
        deliveryTimeSlider.gameObject.SetActive(false);
        interactPoint.gameObject.SetActive(true);

        TempItemCount = 0;
        StopAllCoroutines();
    }

    public override void OnInteractEnd()
    {
        if (TempItemCount >= maxItemsCount) return;
        base.OnInteractEnd();
    }
}
