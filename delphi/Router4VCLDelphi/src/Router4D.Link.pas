unit Router4D.Link;

interface

uses
  Vcl.Controls,
  System.Classes,
  SysUtils,
  Router4D.Interfaces,
  Router4D.Props;

type
  TRouter4DLink = class(TInterfacedObject, iRouter4DLink)
    private
      FAnimation : TProc<TControl>;
    public
    constructor Create;
    destructor Destroy; override;
    class function New : iRouter4DLink;
    function Animation ( aAnimation : TProc<TControl> ) : iRouter4DLink;
    function &To ( aPatch : String; aComponent : TControl ) : iRouter4DLink; overload;
    function &To ( aPatch : String) : iRouter4DLink; overload;
    function &To ( aPatch : String; aProps : TProps; aKey : String = '') : iRouter4DLink; overload;
    function &To ( aPatch : String; aNameContainer : String) : iRouter4DLink; overload;
    function IndexLink ( aPatch : String ) : iRouter4DLink;
  end;

implementation

{ TRouter4DLink }

uses Router4D.History;

function TRouter4DLink.&To( aPatch : String; aComponent : TControl ) : iRouter4DLink;
var
  Component:TComponent;
begin
  Result := Self;
  aComponent.RemoveComponent(aComponent.FindComponent(aPatch));
  Router4DHistory.InstanteObject.UnRender;

  aComponent
    .InsertComponent(
      Router4DHistory
        .GetHistory(aPatch)
        .Render
    );
end;

function TRouter4DLink.&To(aPatch, aNameContainer: String): iRouter4DLink;
var
  aContainer : TControl;
begin
  Result := Self;
  Router4DHistory.InstanteObject.UnRender;
  aContainer := Router4DHistory.GetHistoryContainer(aNameContainer);
  aContainer.RemoveComponent(aContainer.FindComponent(aPatch));

  aContainer
    .InsertComponent(
      Router4DHistory
        .GetHistory(aPatch)
        .Render
    );

    if Assigned(FAnimation) then
      FAnimation(aContainer);

end;

function TRouter4DLink.Animation(aAnimation: TProc<TControl>): iRouter4DLink;
begin
  Result := Self;
  FAnimation := aAnimation;
end;

constructor TRouter4DLink.Create;
begin

end;

destructor TRouter4DLink.Destroy;
begin

  inherited;
end;

function TRouter4DLink.IndexLink(aPatch: String): iRouter4DLink;
begin
  Result := Self;
  Router4DHistory.IndexRouter.RemoveComponent(Router4DHistory.IndexRouter.Components[0]);
  Router4DHistory.InstanteObject.UnRender;
  Router4DHistory
  .IndexRouter
    .InsertComponent(
      Router4DHistory
        .GetHistory(aPatch)
        .Render
    );

  if Assigned(FAnimation) then
  FAnimation(Router4DHistory.IndexRouter);

end;

function TRouter4DLink.&To(aPatch: String) : iRouter4DLink;
begin
  Result := Self;
  Router4DHistory.MainRouter.RemoveComponent(Router4DHistory.MainRouter.Components[0]);
  Router4DHistory.InstanteObject.UnRender;
  Router4DHistory
  .MainRouter
    .InsertComponent(
      Router4DHistory
        .GetHistory(aPatch)
        .Render
    );

  if Assigned(FAnimation) then
    FAnimation(Router4DHistory.MainRouter);

end;

function TRouter4DLink.&To(aPatch: String; aProps: TProps; aKey : String = '') : iRouter4DLink;
begin
  Result := Self;
  Router4DHistory.MainRouter.RemoveComponent(Router4DHistory.MainRouter.Components[0]);
  Router4DHistory.InstanteObject.UnRender;
  Router4DHistory
  .MainRouter
    .InsertComponent(
      Router4DHistory
        .GetHistory(aPatch)
        .Render
    );

  if Assigned(FAnimation) then
    FAnimation(Router4DHistory.MainRouter);

  if aKey <> '' then aProps.Key(aKey);

  GlobalEventBus.Post(aProps);
end;

class function TRouter4DLink.New: iRouter4DLink;
begin
  Result := Self.Create;
end;

end.
