library appstate;

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'app_state.g.dart';

abstract class AppState implements Built<AppState, AppStateBuilder> {
  static Serializer<AppState> get serializer => _$appStateSerializer;

  bool get isLoading;

  AppState._();

  factory AppState([updates(AppStateBuilder b)]) => new _$AppState((b) => b
    ..isLoading = false
    ..update(updates));

  factory AppState.loading() => new AppState((b) => b..isLoading = true);
}
