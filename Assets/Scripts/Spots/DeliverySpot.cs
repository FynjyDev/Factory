using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DeliverySpot : ItemsChanger
{
    public Slider deliveryTimeSlider;
    public InteractPoint interactPoint;
    public Animator deliverySpotAnimator;

    private int _MaxItemsCount => SingletonController.singletonController.config.maxItemsCount;
    private int _DeliveryDelay => SingletonController.singletonController.config.deliveryDelay;

    public override void OnInteractStart()
    {
        if (tempItemCount >= _MaxItemsCount) return;
        base.OnInteractStart();
    }

    public override void OnChange()
    {
        base.OnChange();

        if (tempItemCount == _MaxItemsCount)
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

        deliveryTimeSlider.maxValue = _DeliveryDelay;

        float _deliveryDelayTemp = 0;

        while (_deliveryDelayTemp < _DeliveryDelay)
        {
            deliveryTimeSlider.value = _deliveryDelayTemp;
            _deliveryDelayTemp += Time.fixedDeltaTime;
            yield return null;
        }

        deliverySpotAnimator.SetTrigger("End");
    }

    public void DeliveryAnimatioEnd()
    {
        OnDeliveryEnd();
    }

    private void OnDeliveryEnd()
    {
        deliveryTimeSlider.gameObject.SetActive(false);
        interactPoint.gameObject.SetActive(true);

        tempItemCount = 0;
        StopAllCoroutines();
    }

    public override void OnInteractEnd()
    {
        if (tempItemCount >= _MaxItemsCount) return;
        base.OnInteractEnd();
    }
}
