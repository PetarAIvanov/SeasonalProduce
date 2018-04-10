library actions;

import 'package:built_redux/built_redux.dart';

part 'actions.g.dart';

abstract class AppActions extends ReduxActions {
  AppActions._();

  factory AppActions() => new _$AppActions();
}
