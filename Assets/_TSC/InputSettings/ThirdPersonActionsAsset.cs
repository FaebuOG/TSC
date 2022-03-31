// GENERATED AUTOMATICALLY FROM 'Assets/_TSC/InputSettings/ThirdPersonActionsAsset.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ThirdPersonActionsAsset : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ThirdPersonActionsAsset()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ThirdPersonActionsAsset"",
    ""maps"": [
        {
            ""name"": ""OverWorldPlayer"",
            ""id"": ""235a304f-2f26-4123-a2b9-8be3f30b42ee"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""12c3548c-564b-4367-91e8-05cf954fb6d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0f345447-d0d3-44cd-b3d2-78b801675c32"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8c9f13f1-9f5d-47b9-9031-b122d928eb7b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""b31b71c2-2fdf-4e50-86c8-d314768017fd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""041d1f79-fb69-4e6d-8fc4-2775efed1c45"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9ada7e97-4f50-40b7-ac34-acba3e8dca61"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""791da105-b298-49b0-95c0-4ff3bb232b9f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a490cb27-49c8-474d-bfbd-9274419c80ef"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8e2fa3ff-dcca-4635-9aca-6907b2c0a061"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a7bdc0b-27f3-4dd9-b373-327345029e31"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""gamepad"",
            ""bindingGroup"": ""gamepad"",
            ""devices"": []
        }
    ]
}");
        // OverWorldPlayer
        m_OverWorldPlayer = asset.FindActionMap("OverWorldPlayer", throwIfNotFound: true);
        m_OverWorldPlayer_Move = m_OverWorldPlayer.FindAction("Move", throwIfNotFound: true);
        m_OverWorldPlayer_Look = m_OverWorldPlayer.FindAction("Look", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // OverWorldPlayer
    private readonly InputActionMap m_OverWorldPlayer;
    private IOverWorldPlayerActions m_OverWorldPlayerActionsCallbackInterface;
    private readonly InputAction m_OverWorldPlayer_Move;
    private readonly InputAction m_OverWorldPlayer_Look;
    public struct OverWorldPlayerActions
    {
        private @ThirdPersonActionsAsset m_Wrapper;
        public OverWorldPlayerActions(@ThirdPersonActionsAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_OverWorldPlayer_Move;
        public InputAction @Look => m_Wrapper.m_OverWorldPlayer_Look;
        public InputActionMap Get() { return m_Wrapper.m_OverWorldPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OverWorldPlayerActions set) { return set.Get(); }
        public void SetCallbacks(IOverWorldPlayerActions instance)
        {
            if (m_Wrapper.m_OverWorldPlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_OverWorldPlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_OverWorldPlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_OverWorldPlayerActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_OverWorldPlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_OverWorldPlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_OverWorldPlayerActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_OverWorldPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public OverWorldPlayerActions @OverWorldPlayer => new OverWorldPlayerActions(this);
    private int m_gamepadSchemeIndex = -1;
    public InputControlScheme gamepadScheme
    {
        get
        {
            if (m_gamepadSchemeIndex == -1) m_gamepadSchemeIndex = asset.FindControlSchemeIndex("gamepad");
            return asset.controlSchemes[m_gamepadSchemeIndex];
        }
    }
    public interface IOverWorldPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}
