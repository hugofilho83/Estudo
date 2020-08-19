unit Router4D.Sidebar;

interface

uses
  Classes,
  SysUtils,
  Vcl.Graphics,
  Vcl.Controls,
  Router4D.Interfaces,
  System.UITypes;

type
  TRouter4DSidebar = class(TInterfacedObject, iRouter4DSidebar)
    private
      FName : String;
      FMainContainer : TControl;
      FFontSize : Integer;
      FFontColor : TAlphaColor;
      FItemHeigth : Integer;
      FLinkContainer : TControl;
      FAnimation : TProc<TControl>;
    public
      constructor Create;
      destructor Destroy; override;
      class function New : iRouter4DSidebar;
      function Animation ( aAnimation : TProc<TControl> ) : iRouter4DSidebar;
      function Name ( aValue : String ) : iRouter4DSidebar; overload;
      function MainContainer ( aValue : TControl ) : iRouter4DSidebar; overload;
      function Name  : String; overload;
      function MainContainer  : TControl; overload;
      function FontSize ( aValue : Integer ) : iRouter4DSidebar;
      function FontColor ( aValue : TColor ) : iRouter4DSidebar;
      function ItemHeigth ( aValue : Integer ) : iRouter4DSidebar;
      function LinkContainer ( aValue : TControl ) : iRouter4DSidebar;
      //function RenderToListBox : iRouter4DSidebar;
  end;

implementation

uses
  Router4D,
  Router4D.History,
  Router4D.Utils;

{ TRouter4DSidebar }

function TRouter4DSidebar.Animation(
  aAnimation: TProc<TControl>): iRouter4DSidebar;
begin
  Result := Self;
  FAnimation := aAnimation;
end;

constructor TRouter4DSidebar.Create;
begin
  FName := 'SBIndex';
  FLinkContainer := Router4DHistory.MainRouter;
end;

destructor TRouter4DSidebar.Destroy;
begin

  inherited;
end;

function TRouter4DSidebar.FontColor(aValue: TColor): iRouter4DSidebar;
begin
  Result := Self;
  FFontColor := aValue;
end;

function TRouter4DSidebar.FontSize(aValue: Integer): iRouter4DSidebar;
begin
  Result := Self;
  FFontSize := aValue;
end;

function TRouter4DSidebar.ItemHeigth(aValue: Integer): iRouter4DSidebar;
begin
  Result := Self;
  FItemHeigth := aValue;
end;

function TRouter4DSidebar.LinkContainer(aValue: TControl): iRouter4DSidebar;
begin
  Result := Self;
  FLinkContainer := aValue;
end;

function TRouter4DSidebar.MainContainer(aValue: TControl): iRouter4DSidebar;
begin
  Result := Self;
  FMainContainer := aValue;
end;

function TRouter4DSidebar.MainContainer: TControl;
begin
  Result := FMainContainer;
end;

function TRouter4DSidebar.Name(aValue: String): iRouter4DSidebar;
begin
  Result := Self;
  FName := aValue;
end;

function TRouter4DSidebar.Name: String;
begin
  Result := FName;
end;

class function TRouter4DSidebar.New: iRouter4DSidebar;
begin
    Result := Self.Create;
end;

//function TRouter4DSidebar.RenderToListBox: iRouter4DSidebar;
//var
//  aListBox : TListBox;
//  aListBoxItem : TListBoxItem;
//  aItem : TCachePersistent;
//  AListBoxSearch : TSearchBox;
//begin
//  aListBox             := TListBox.Create(FMainContainer);
//  aListBox.Align       := TAlignLayout.alClient;
//  aListBox.ItemHeight  := FItemHeigth;
//  aListBox.StyleLookup := 'transparentlistboxstyle';
//
//  aListBox.BeginUpdate;
//
//  AListBoxSearch := TSearchBox.Create(aListBox);
//  AListBoxSearch.Height := FItemHeigth - 25;
//  aListBox.AddObject(AListBoxSearch);
//
//  for aItem in Router4DHistory.RoutersListPersistent.Values do
//  begin
//    if AItem.FisVisible and (AItem.FSBKey = FName) then
//    begin
//      aListBoxItem := TListBoxItem.Create(aListBox);
//      aListBoxItem.Parent := aListBox;
////      aListBoxItem.StyledSettings:=[TStyledSetting.Other];
//      aListBoxItem.TextSettings.Font.Size := FFontSize;
//      aListBoxItem.FontColor := FFontColor;
//      aListBoxItem.Text := aItem.FPatch;
//      aListBox.AddObject(aListBoxItem);
//    end;
//  end;
//  aListBox.EndUpdate;
//
//
//  Router4DHistory.AddHistoryConteiner(FName, FLinkContainer);
//
//  aListBox.OnClick :=
//
//  TNotifyEventWrapper
//    .AnonProc2NotifyEvent(
//      aListBox,
//      procedure(Sender: TObject; Aux : String)
//      begin
//        TRouter4D
//        .Link
//          .Animation(
//            procedure ( aObject : TControl )
//            begin
//              TLayout(aObject).Opacity := 0;
//              TLayout(aObject).AnimateFloat('Opacity', 1, 0.2);
//            end)
//          .&To(
//            (Sender as TListBox).Items[(Sender as TListBox).ItemIndex],
//            Aux
//          )
//      end,
//      FName
//    );
//
//  FMainContainer.AddObject(aListBox);
//end;

end.
