using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

public class PreparationData : MonoBehaviour
{
    [SerializeField] private PreparationsController _preparationsController;
    [SerializeField] private UIPreparation _uiPreparation;

    private GameObject _selectedObject;
    private IHelicopterPart _selectedHelicopterPart;
    private GameObject _selectedPreview;
    private int _selectedObjectPrevious = -1;

    public GameObject SelectedObject
    {
        get { return _selectedObject; }
        set
        {
            if (value == null)
                _selectedHelicopterPart = null;
            else
                _selectedHelicopterPart = value.GetComponent<IHelicopterPart>();
            _selectedObject = value;
        }
    }
    public IHelicopterPart SelectedHelicopterPart
    {
        get { return _selectedHelicopterPart; }
    }
    public GameObject SelectedPreview
    {
        get { return _selectedPreview; }
        set { _selectedPreview = value; }
    }
    public int SelectedObjectPrevious
    {
        get { return _selectedObjectPrevious; }
        set { _selectedObjectPrevious = value; }
    }

    public GameObject ChangePart(int partId) //Замена запчастей вертолёта, если изменяется, UPD: возвращаемый объект на данный момент рудементарен
    {
        var objectId = _selectedHelicopterPart.Id;
        if (partId != objectId)
        {
            SelectedObjectPrevious = objectId;
            switch (SelectedHelicopterPart.Type)
            {
                case "Gun":
                    SwitchGun(partId);
                    break;
                default:
                    return SwitchObject(partId);
            }
        }
        return null;
    }
    public GameObject TryToChangePart(IHelicopterPart partToSelect, int partId)
    {
        SelectedObject = partToSelect.partGameObject;
        ChangePart(partId);
        return SelectedObject;
    }
    private void SwitchGun(int id)
    {
        Gun newGun = Resources.Load<Gun>($"ScriptableObjects/{SelectedObject.tag}/part_{id}");
        SelectedObject.GetComponent<GunInfo>().Gun = newGun;
    }
    private GameObject SwitchObject(int id)
    {
        IHelicopterPart helicopterPart = _selectedHelicopterPart;
        SelectedObject.SetActive(false);
        SelectedObject = helicopterPart.ObjectList[id].gameObject;
        SelectedObject.SetActive(true);
        return SelectedObject;
    }

}
